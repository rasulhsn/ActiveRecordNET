﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ActiveRecordNET.Lib.Extensions
{
    public class SelectCommandBuilder : IDbCommandBuilder
    {
        private readonly string _tableName;
        private readonly AdoCommandBuilder _adoCommandBuilder;
        private readonly ISelectQueryBuilder _selectQueryBuilder;
        private readonly List<ColumnQuery> _columnQueryInfos;

        public SelectCommandBuilder(string tableName, AdoCommandBuilder adoCommandBuilder, ISelectQueryBuilder selectQueryBuilder)
        {
            _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            _selectQueryBuilder = selectQueryBuilder ?? throw new ArgumentNullException(nameof(selectQueryBuilder));
            _adoCommandBuilder = adoCommandBuilder ?? throw new ArgumentNullException(nameof(adoCommandBuilder));

            _columnQueryInfos = new List<ColumnQuery>();
        }

        public ColumnQuery Column(string columnName)
        {
            ColumnQuery columnInfo = new ColumnQuery(columnName);
            _columnQueryInfos.Add(columnInfo);

            return columnInfo;
        }

        IDbCommand IDbCommandBuilder.Build()
        {
            IDbCommand BuildCommand(object instance)
            {
                string queryStr = ((IQueryBuilder)instance).Build();
                _adoCommandBuilder.SetCommand(queryStr);

                return ((IDbCommandBuilder)_adoCommandBuilder).Build();
            }

            IFromQueryBuilder fromQueryBuilder = null;

            var selectColumns = _columnQueryInfos.Where(x => x.OperationName == nameof(ColumnQuery.Only))
                            .Select(x => x.ColumnName);
            
            if (selectColumns != null && selectColumns.Any())
            {
                fromQueryBuilder = _selectQueryBuilder.Select(selectColumns)
                                                    .From(_tableName);
            }
            else
            {
                fromQueryBuilder = _selectQueryBuilder.From(_tableName);
            }

            var conditionColumns = _columnQueryInfos.Where(x => x.OperationName == nameof(ColumnQuery.EqualTo)
                                                          || x.OperationName == nameof(ColumnQuery.Len));

            if (conditionColumns != null && conditionColumns.Any())
            {
                object queryBuilderInstance = null;

                foreach (var columnInfo in conditionColumns)
                {
                    if (queryBuilderInstance is null)
                    {
                        queryBuilderInstance = fromQueryBuilder.Where(columnInfo.ColumnName);
                        queryBuilderInstance = InvokeQueryBuilder(queryBuilderInstance, columnInfo);
                    }
                    else
                    {
                        queryBuilderInstance = InvokeQueryBuilder(queryBuilderInstance, columnInfo);
                    }
                }
                
                return BuildCommand(queryBuilderInstance);
            }

            return BuildCommand(fromQueryBuilder);
        }

        private object InvokeQueryBuilder(object instance, ColumnQuery columnInfo)
        {
            void DefaultInvoke()
            {
                var methodInfo = instance.GetType().GetMethod(columnInfo.OperationName);
                instance = methodInfo.Invoke(instance, new object[] { columnInfo.Value });
            }

            if (instance is IWhereQueryBuilder)
            {
                DefaultInvoke();
            }
            else if (instance is IConditionQueryBuilder)
            {
                if (columnInfo.And)
                {
                    instance = ((IConditionQueryBuilder)instance).And(columnInfo.ColumnName);
                    DefaultInvoke();
                }
                else
                {
                    instance = ((IConditionQueryBuilder)instance).Or(columnInfo.ColumnName);
                    DefaultInvoke();
                }
            }
            else
            {
                throw new InvalidOperationException("");
            }

            return instance;
        }

        public class ColumnQuery
        {
            private readonly string _columnName;
            private object _value;
            private string _operationName;
            private bool _and;

            internal string ColumnName => _columnName;
            internal string OperationName => _operationName;
            internal object Value => _value;
            internal bool And => _and;

            internal ColumnQuery(string columnName)
            {
                _columnName = columnName;
            }

            public void EqualTo(string value, bool and = true)
            {
                _operationName = nameof(EqualTo);
                _value = value;
                _and = and;
            }
            public void Len(int value, bool and = true)
            {
                _operationName = nameof(Len);
                _value = value;
                _and = and;
            }
            public void Only()
            {
                _operationName = nameof(Only);
                _value = null;
            }
        }
    }
}

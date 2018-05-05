using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.FrameworkHelp.Tools
{
    public class DataMappingAttribute : Attribute
    {
        private string m_ColumnName;
        private DbType m_DbType;

        public DataMappingAttribute(string columnName, DbType dbType)
        {
            m_ColumnName = columnName;
            m_DbType = dbType;
        }

        public string ColumnName
        {
            get { return m_ColumnName; }
        }

        public DbType DbType
        {
            get { return m_DbType; }
        }
    }
}

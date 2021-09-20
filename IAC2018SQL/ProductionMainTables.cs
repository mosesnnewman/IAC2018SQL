using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using System.Security.Permissions;
namespace IAC2021SQL
{


    partial class ProductionMainTables
    {
        partial class AmortTempDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class ACCOUNTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class AMORTIZEDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class ALTNAMEDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class COMMENTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNBANKDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class DEALHISTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class DEALERDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class CustBankDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class CUSTOMERDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class CUSTHISTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }


        partial class CUSTHISTDataTable
        {
        }

        partial class OPNDEALRDataTable
        {
        }

        partial class CUSTOMERDataTable
        {
        }

        partial class CONTINGDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class EmailDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class MASTHISTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class MACONTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class MASTERDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class NOTICEDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNCONTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNCUSTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNHCUSTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNHDEALDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNPAYDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class PAYMENTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNNOTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNRATEDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNCOMMDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNDEALRDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNUPDATDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class OPNMCONTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class ORECEIPTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class ReceiptDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class TVAPRInfoDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class TVAmortMonthlyDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class TVAmortDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class ULISTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class VEHICLEDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }
    }
}

namespace IAC2021SQL.ProductionMainTablesTableAdapters
{
    partial class CustBankTableAdapter
    {
    }

    partial class CUSTHISTTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }



        public void CloseConnection()
        {
            _connection.Close();
        }

        public SqlTransaction BeginTransaction(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }

    }

    partial class DEALERTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class OPNHCUSTTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }



        public void CloseConnection()
        {
            _connection.Close();
        }

        public SqlTransaction BeginTransaction(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }

    }

    partial class OPNHDEALTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {

                InitCommandCollection();

                _commandCollection[1].CommandText = strCommand;
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }



        public void CloseConnection()
        {
            _connection.Close();
        }

        public SqlTransaction BeginTransaction(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }

    }

    partial class CUSTOMERTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class OPNCUSTTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class VEHICLETableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class CONTINGTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class OPNDEALRTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class OPNPAYTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class PAYMENTTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class MASTHISTTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class AMORTIZETableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class MASTERTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = _connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

    partial class DEALHISTTableAdapter
    {
        public void CustomizeFill(string strCommand)
        {

            if (strCommand.Length > 0)
            {
                InitCommandCollection();
                switch (strCommand.ToString().Substring(0, 6).ToUpper())
                {
                    case "DELETE":
                        _commandCollection[4].CommandText = strCommand;
                        break;
                    case "UPDATE":
                        _commandCollection[3].CommandText = strCommand;
                        break;
                    case "INSERT":
                        _commandCollection[2].CommandText = strCommand;
                        break;
                    default:
                        _commandCollection[1].CommandText = strCommand;
                        break;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
                _connection.Open();
            }
            return _connection;
        }



        public void CloseConnection()
        {
            _connection.Close();
        }

        public SqlTransaction BeginTransaction(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                throw new System.Exception("Connection State cannot be closed for a new transaction");
            }

            SqlTransaction tran = connection.BeginTransaction(IsolationLevel.Serializable);
            foreach (SqlCommand cmd in _commandCollection)
            {
                cmd.Transaction = tran;
            }

            return tran;
        }
    }

}

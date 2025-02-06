using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.Data.SqlClient;
using System.Security.Permissions;
namespace IAC2018SQL
{


    partial class WSSummaryVirtualTables
    {
        partial class OPN_WS_DEALER_PAYDataTable
        {
        }

        partial class OPN_WS_DEALERDataTable
        {
        }

        partial class WS_OPNDEALR_CONTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class WS_OPNNOT_DEALERDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class WS_DEALERDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class WS_DEALER_CONTDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);

            }
        }

        partial class WS_DEALER_PAYDataTable
        {
            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new ArgumentNullException("info");
                base.GetObjectData(info, context);
            }
        }

        partial class WS_NOTICE_DEALERDataTable
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

namespace IAC2018SQL.WSSummaryVirtualTablesTableAdapters
{
    partial class OPN_WS_DEALER_PAYTableAdapter
    {
    }

    public partial class OPN_WS_DEALERTableAdapter {
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidPOCOGenerator
{
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            try
            {
                FrmConnection fc = new FrmConnection();
                fc.ShowDialog();
                if (fc.DialogResult == DialogResult.OK)
                {
                    switch (SgBase.Instance.DBType)
                    {
                        case "MsSql":
                            string[] restric = new string[4];
                            restric[3] = "BASE TABLE";
                            FillObjects(SgMsSqlCon.Instance.Con.GetSchema("Tables",restric));
                            break;
                        case "Oracle":
                            break;
                        case "Sqlite":
                            break;
                        default:
                            break;
                    }
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       
        private void ckAllObjects_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ObjectList.Items.Count; i++)
                {
                    ObjectList.SetItemChecked(i, ckAllObjects.Checked);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetColumns()
        {
            try
            {
                switch (SgBase.Instance.DBType)
                {
                    case "MsSql":
                        string[] restric = new string[4];
                        restric[2] = ObjectList.GetItemText(ObjectList.SelectedItem);
                        if (rbPoco.Checked)
                        {
                            SetPOCOColumns(SgMsSqlCon.Instance.Con.GetSchema("Columns", restric));
                        }
                        else
                        {
                            if (rbDao.Checked)
                            {
                                StringBuilder sbci = new StringBuilder(" select ic.column_id,ic.index_column_id,t.name table_name ");
                                sbci.Append(" ,c.is_identity,c.is_nullable,c.max_length,c.\"precision\",c.\"scale\" ");
                                sbci.Append(" ,c.name column_name,i.is_unique,i.is_primary_key from sys.indexes i ");
                                sbci.Append("inner join sys.index_columns ic on  i.object_id = ic.object_id and i.index_id = ic.index_id");
                                sbci.Append(" inner join sys.columns c on ic.object_id = c.object_id and ic.column_id = c.column_id ");
                                sbci.Append(" inner join sys.tables t on i.object_id = t.object_id");

                                DataTable dtColumnInfo = SgMsSqlCon.GetData(sbci.ToString());

                                SetDAOColumns(SgMsSqlCon.Instance.Con.GetSchema("Columns", restric), dtColumnInfo);
                            }
                        }
                        
                        break;
                    case "Oracle":
                        break;
                    case "Sqlite":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void FillObjects(DataTable dtObjects)
        {
            try
            {
                foreach (DataRow item in dtObjects.Rows)
                {
                    ObjectList.Items.Add(item["TABLE_NAME"], false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SetPOCOColumns(DataTable dtColumns)
        {
            try
            {
                StringBuilder sbClass = new StringBuilder();
                txtClass.Clear();
                string tableName = ObjectList.GetItemText(ObjectList.SelectedItem);
                sbClass.AppendLine("package " + txtPackage.Text + ";");
                sbClass.AppendLine();
                int iText = sbClass.Length;

                sbClass.AppendLine();
                sbClass.AppendLine("public class " + SgBase.toUpperCamel(tableName) + " {");
                sbClass.AppendLine();
                DataTable dtOrder = dtColumns.Select(null, "ordinal_position asc").CopyToDataTable();


                foreach (DataRow item in dtOrder.Rows)
                {
                    String stype = GetClassType(item["data_type"]);
                    String name = SgBase.toString(item["column_name"]);
                    sbClass.AppendLine("private " + stype + " " + name.ToLower() + " ;");
                    sbClass.AppendLine();
                    #region declare column properties
                    if (ckProperties.Checked)
                    {
                        sbClass.Append("public " + stype + " get" + SgBase.toUpperCamel(name));
                        sbClass.AppendLine("() {");
                        sbClass.AppendLine("return " + name.ToLower() + "; }");
                        sbClass.AppendLine();

                        sbClass.Append("public void  set" + SgBase.toUpperCamel(name));
                        sbClass.AppendLine("(" + stype + " " + name.ToLower() + ") {");
                        sbClass.AppendLine("this." + name.ToLower() + " = " + name.ToLower() + "; }");

                        sbClass.AppendLine();
                    }
                    #endregion

                    #region declare column names
                    if (ckColumnNameStrings.Checked)
                    {
                        sbClass.AppendLine("public static final String " + SgBase.toLowerCamel(name) + "Cn = \"" + name + "\";");
                        sbClass.AppendLine();
                    }

                    #endregion

                    #region test code
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("ordinal_position =" + SgBase.toString(item["ordinal_position"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("column_default =" + SgBase.toString(item["column_default"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("is_nullable =" + SgBase.toString(item["is_nullable"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("data_type =" + SgBase.toString(item["data_type"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("character_maximum_length =" + SgBase.toString(item["character_maximum_length"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("character_octet_length =" + SgBase.toString(item["character_octet_length"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("numeric_precision =" + SgBase.toString(item["numeric_precision"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText("ordinal_position =" + SgBase.toString(item["numeric_scale"]));
                    //txtClass.AppendText(" ");
                    //txtClass.AppendText(Environment.NewLine + "datetime_precision =" + SgBase.toString(item["datetime_precision"]));
                    //txtClass.AppendText(Environment.NewLine + SgBase.toString(item["data_type"]));
                    #endregion


                } //foreach

                if (ckImports.Checked)
                {
                    string sDateImport = "import java.util.Date;";
                    sbClass.Insert(iText, sDateImport + Environment.NewLine + Environment.NewLine, 1);

                }

                if (ckTableName.Checked)
                {
                    sbClass.AppendLine("public static final String TableName = \"" + tableName + "\";");
                    sbClass.AppendLine();
                }

                #region all columns array
                if (ckAllColumnsArray.Checked)
                {
                    StringBuilder sballcols = new StringBuilder("public static final String[] AllColumns = new String[] {");
                    for (int i = 0; i < dtOrder.Rows.Count; i++)
                    {
                        sballcols.Append("\"" + SgBase.toString(dtOrder.Rows[i]["column_name"]) + "\"");
                        if (i < dtOrder.Rows.Count -1)
                        {
                            sballcols.Append(", ");
                        }
                    }

                    sballcols.Append("} ");
                    sbClass.AppendLine(sballcols.ToString());
                    sbClass.AppendLine();
                }
                #endregion

                #region all columns string
                if (ckAllColumnsString.Checked)
                {
                    StringBuilder sball = new StringBuilder("public static final String All = \"");
                    for (int i = 0; i < dtOrder.Rows.Count; i++)
                    {
                        sball.Append(SgBase.toString(dtOrder.Rows[i]["column_name"]));
                        if (i < dtOrder.Rows.Count -1)
                        {
                            sball.Append(", ");
                        }
                    }
                    sball.Append("\"; ");
                    sbClass.AppendLine(sball.ToString());
                    sbClass.AppendLine();
                }
                #endregion

                sbClass.AppendLine();
                sbClass.AppendLine("}");
                txtClass.Text = sbClass.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SetDAOColumns(DataTable dtColumns, DataTable dtColumnInfo)
        {
            try
            {
                
                StringBuilder sbClass = new StringBuilder();
                txtClass.Clear();
                string tableName = ObjectList.GetItemText(ObjectList.SelectedItem);
                sbClass.AppendLine("package " + txtPackage.Text + ";");
                sbClass.AppendLine();
                int iText = sbClass.Length;

                sbClass.AppendLine();
                sbClass.AppendLine("@DatabaseTable(tableName = \"" + tableName + "\")");
                sbClass.AppendLine("public class " + SgBase.toUpperCamel(tableName) + " implements Serializable {");
                sbClass.AppendLine();
                DataTable dtOrder = dtColumns.Select(null, "ordinal_position asc").CopyToDataTable();

                StringBuilder sballcols = new StringBuilder("public " + SgBase.toUpperCamel(tableName) );
                StringBuilder sbVariables = new StringBuilder(" ( ");

                #region class OrmLite forced constructor
                sbClass.AppendLine("public " + SgBase.toUpperCamel(tableName) + "() {");
                sbClass.AppendLine("// all persisted classes must define a no-arg constructor");
                sbClass.AppendLine("// with at least package visibility");
                sbClass.AppendLine("}");
                #endregion

                foreach (DataRow item in dtOrder.Rows)
                {
                    String stype = GetClassType(item["data_type"]);
                    String name = SgBase.toString(item["column_name"]);
                    int position = Convert.ToInt32(item["ordinal_position"]);

                    #region column properties
                    bool is_identity = false;
                    bool is_primary = false;
                    bool is_unique = false;

                    if (dtColumnInfo != null && dtColumnInfo.Select("column_name = '" + name +"' and table_name='" + tableName + "'").Count() > 0)
                    {
                        DataRow drCol = dtColumnInfo.Select("column_name = '" + name + "' and table_name='" + tableName + "'").FirstOrDefault();
                        is_identity = SgBase.toBoolFalse(drCol["is_identity"]);
                        is_primary = SgBase.toBoolFalse(drCol["is_primary_key"]);
                        is_unique = SgBase.toBoolFalse(drCol["is_unique"]);
                    }
                    #endregion

                    #region database notation
                    sbClass.Append(" @DatabaseField ( columnName=\"" + name + "\"");
                    if (stype.ToLower().Contains("array"))
                    {
                        sbClass.Append(" , dataType = DataType.BYTE_ARRAY ");
                    }

                    if (!string.IsNullOrEmpty(SgBase.toString(item["column_default"])))
                    {
                       
                       sbClass.Append(" , defaultValue=\"" + SgBase.toString(item["column_default"]) + "\"");
                      
                    }

                    if (!string.IsNullOrEmpty(SgBase.toString(item["is_nullable"])) && !SgBase.toString(item["is_nullable"]).ToLower().Equals("no"))
                    {
                        sbClass.Append(" , canBeNull= true");
                    }
                    else
                    {
                        sbClass.Append(" , canBeNull= false");
                    }

                    if (stype.Equals("String") && SgBase.toInt(item["character_maximum_length"]) > 0)
                    {
                        sbClass.Append(" , width=" + SgBase.toString(item["character_maximum_length"]) );
                    }

                    if (is_identity)
                    {
                        sbClass.Append(" , generatedId= true");
                    }
                    if (is_primary && !is_identity)
                    {
                        sbClass.Append(" , id = true");
                    }

                    sbClass.AppendLine(")");
                    #endregion

                    //variable declaration
                    if (stype.ToLower().Contains("array"))
                    {
                        sbClass.AppendLine(Environment.NewLine + " private byte[] " + name + " ;");
                        sbClass.AppendLine();
                    }
                    else
                    {
                        sbClass.AppendLine(Environment.NewLine + " private " + stype + " " + name + " ;");
                        sbClass.AppendLine();
                    }

                    #region all columns constructor
                    if (position > 1)
                    {
                        sbVariables.Append(", ");
                    }
                    sbVariables.Append(stype + " " + SgBase.toLowerCamel(name));

                   
                    #endregion

                    #region declare column properties
                    if (ckProperties.Checked)
                    {
                        if (stype.ToLower().Contains("array"))
                        {
                            sbClass.Append("public byte[] get" + SgBase.toUpperCamel(name));
                            sbClass.AppendLine("() {");
                            sbClass.AppendLine("return " + name.ToLower() + "; }");
                            sbClass.AppendLine();

                            sbClass.Append("public void  set" + SgBase.toUpperCamel(name));
                            sbClass.AppendLine("( byte[] " + name.ToLower() + ") {");
                            sbClass.AppendLine("this." + name.ToLower() + " = " + name.ToLower() + "; }");
                        }
                        else
                        {
                            sbClass.Append("public " + stype + " get" + SgBase.toUpperCamel(name));
                            sbClass.AppendLine("() {");
                            sbClass.AppendLine("return " + name.ToLower() + "; }");
                            sbClass.AppendLine();

                            sbClass.Append("public void  set" + SgBase.toUpperCamel(name));
                            sbClass.AppendLine("(" + stype + " " + name.ToLower() + ") {");
                            sbClass.AppendLine("this." + name.ToLower() + " = " + name.ToLower() + "; }");
                        }
                        sbClass.AppendLine();
                    }
                    #endregion
                    

                } //foreach

                sbVariables.Append(" ) { ");
                for (int i = 0; i < dtOrder.Rows.Count; i++)
                {
                    sballcols.AppendLine(sbVariables.ToString());
                    string cname = SgBase.toLowerCamel(SgBase.toString(dtOrder.Rows[i]["column_name"]));
                   
                    sballcols.AppendLine ("this." + cname + " = " + cname + ";");
                    
                }

                sballcols.AppendLine(" } ");

                if (ckImports.Checked)
                {
                    StringBuilder  sbImports = new StringBuilder();
                    sbImports.AppendLine("import com.j256.ormlite.field.DataType;");
                    sbImports.AppendLine("import com.j256.ormlite.field.DatabaseField;");
                    sbImports.AppendLine("import com.j256.ormlite.table.DatabaseTable;");
                    sbImports.AppendLine("import java.io.Serializable;");
                    sbImports.AppendLine("import java.util.Date;");

                    sbClass.Insert(iText, sbImports.ToString() + Environment.NewLine + Environment.NewLine, 1);

                }
                
                sbClass.AppendLine();
                sbClass.AppendLine("}");
                txtClass.Text = sbClass.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SetDDLColumns(DataTable dtColumns, DataTable dtColumnInfo)
        {
            try
            {
                StringBuilder sbClass = new StringBuilder();
                txtClass.Clear();
                string tableName = ObjectList.GetItemText(ObjectList.SelectedItem);
                sbClass.AppendLine("package " + txtPackage.Text + ";");
                sbClass.AppendLine();
                sbClass.AppendLine("import android.database.sqlite.*;");
                int iText = sbClass.Length;

                sbClass.AppendLine();
                sbClass.AppendLine("public class Ddl" + SgBase.toUpperCamel(tableName) + "(SQLiteDatabase db) {");
                sbClass.AppendLine();

                sbClass.AppendLine("public static void Create" + SgBase.toUpperCamel(tableName) + " {");
                sbClass.AppendLine();
                sbClass.AppendLine("StringBuilder sqlStr = new StringBuilder();");
                sbClass.AppendLine("try");
                sbClass.AppendLine("{");
                sbClass.AppendLine("sqlStr.append(\"DROP TABLE  IF EXISTS " + tableName + " \");");
                sbClass.AppendLine(" db.execSQL(sqlStr.toString()); ");
                sbClass.AppendLine("sqlStr = new StringBuilder(); ");
                sbClass.AppendLine("sqlStr.append(\"CREATE TABLE " + tableName + " (\"); ");

                DataTable dtOrder = dtColumns.Select(null, "ordinal_position asc").CopyToDataTable();
                string pk = null;
                foreach (DataRow item in dtOrder.Rows)
                {
                    String stype = GetSqlLiteType(item["data_type"]);
                    String name = SgBase.toString(item["column_name"]);
                    int position = Convert.ToInt32(item["ordinal_position"]);

                    #region column properties
                    bool is_identity = false;
                    bool is_primary = false;
                    bool is_unique = false;

                    if (dtColumnInfo != null && dtColumnInfo.Select("column_name = '" + name + "' and table_name='" + tableName + "'").Count() > 0)
                    {
                        DataRow drCol = dtColumnInfo.Select("column_name = '" + name + "' and table_name='" + tableName + "'").FirstOrDefault();
                        is_identity = SgBase.toBoolFalse(drCol["is_identity"]);
                        is_primary = SgBase.toBoolFalse(drCol["is_primary_key"]);
                        is_unique = SgBase.toBoolFalse(drCol["is_unique"]);
                    }
                    #endregion

                    #region llave
                    if (is_primary)
                    {
                        if (string.IsNullOrEmpty(pk))
                        {
                            pk = name;
                        } else
                        {
                            pk = pk + "," + name;
                        }
                    }
                    #endregion


                }

                sbClass.AppendLine("sqlStr.append(\" PRIMARY KEY(" + pk + ")\");");
                sbClass.AppendLine("sqlStr.append(\"); \"); ");
                sbClass.AppendLine();
                sbClass.AppendLine("}");
                txtClass.Text = sbClass.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string GetClassType(object fromtype)
        {
            try
            {
                string restype = null;
                switch (SgBase.toString(fromtype).ToLower())
                {
                    case "bigint":
                        restype = "long";
                        break;
                   
                    case "int":
                        restype = "int";
                        break;
                    case "numeric":
                        restype = "double";
                        break;
                    case "bit":
                        restype = "boolean";
                        break;
                    case "datetime":
                        restype = "Date"; //import java.util.Date;
                        break;
                    case "binary":
                        restype = "DataType.BYTE_ARRAY";
                        break;
                    case "char":
                        restype = "long";
                        break;
                    case "decimal":
                        restype = "double";
                        break;
                    case "float":
                        restype = "float";
                        break;
                    case "image":
                        restype = "DataType.BYTE_ARRAY";
                        break;
                    case "blob":
                        restype = "DataType.BYTE_ARRAY";
                        break;
                    case "real":
                        restype = "float";
                        break;
                    case "smallint":
                        restype = "int";
                        break;
                   
                    default:
                       restype = "String";
                        break;
                }

                return restype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string GetSqlLiteType(object fromtype)
        {
            try
            {
                string restype = null;
                switch (SgBase.toString(fromtype).ToLower())
                {
                    case "string":
                        restype = "TEXT";
                        break;
                    case "bit":
                        restype = "BOOLEAN";
                        break;
                    case "datetime":
                        restype = "NUMERIC"; 
                        break;
                    case "binary":
                        restype = "BLOB";
                        break;
                    case "char":
                        restype = "TEXT";
                        break;
                    case "decimal":
                        restype = "NUMERIC";
                        break;
                    case "float":
                        restype = "REAL";
                        break;
                    case "image":
                        restype = "BLOB";
                        break;

                    case "real":
                        restype = "float";
                        break;
                    
                    default:
                        restype = SgBase.toString(fromtype);
                        break;
                }

                return restype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ckProperties_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ckColumnNameStrings_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ckAllColumnsArray_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ckAllColumnsString_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ckTableName_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rbDao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rbPoco_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetColumns();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

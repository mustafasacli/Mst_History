using System;
using System.Data;
using System.Windows.Forms;
using Mst.Data.Management;
using System.Diagnostics;
using System.Collections;
using Mst.Data.DBConnection;

namespace MstTestWFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVeriGetir_Click(object sender, EventArgs e)
        {
            try
            {
                // string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=374phjg2346rgy84j67uwye387;Database=template_postgis_20;";
                // "Server=localhost;Database=template_postgis_20;User Id=postgres;Password=374phjg2346rgy84j67uwye387;";
                Stopwatch stpwtch = new Stopwatch(); stpwtch.Start();

                Connection postConn = new Connection(ConnectionTypes.MySQL,
                    "Server=localhost;database=gurutest;UID=root;password=123123;"
                    //@"Server=localhost;Database=template_postgis_20;USER ID=postgres;PASSWORD=374phjg2346rgy84j67uwye387gh;"
                    );
                /*
                EnterpriseDBManager manager = new EnterpriseDBManager(
                    @"Server=localhost;Database=template_postgis_20;USER ID=postgres;PASSWORD=123123;"
                   @"Server=localhost;Database=template_postgis_20;USER ID=postgres;PASSWORD=374phjg2346rgy84j67uwye387;"
                     );*/

                //DataTable dT = manager.GetResultSetOfQuery(
                DataTable dT = postConn.GetResultSet(CommandType.Text,
                    "Select * From gurutest.Person;"
                    ).Tables[0];
                dataGridView1.DataSource = dT;
                stpwtch.Stop();
                MessageBox.Show(stpwtch.ElapsedMilliseconds.ToString());

                /*
                string str = @"Provider=OraOLEDB.Oracle;Data Source=//10.0.0.121:1521/NCARE; User Id=scott;Password=tiger;";
                OracleConnection Conn = new OracleConnection(str);
                Conn.Open();
                OracleCommand cmd = Conn.CreateCommand();
                cmd.CommandText = "Select * From Test2";
                DataSet dS = new DataSet();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dS);
                 */
                /*
                OracleManager OracMan = new OracleManager();
                DataTable dT = OracMan.GetResultSetOfQuery().Tables[0];
                 *  */




            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCreateAccessFile_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable hashT = new Hashtable();
                //hashT.Add("@ILId", 70);
                Stopwatch stpwtch = new Stopwatch();
                stpwtch.Start();
                MsSQLManager sqm = new MsSQLManager(
                    //"Server=10.0.0.145;Database=InCareTest;User Id=incareadmin;Password=incareadmin");
                        "Server=KRK\\SQLEXPRESS; Database=myDB; Integrated Security=SSPI;");

                DataTable dT = sqm.GetResultSetOfQuery("Select * from Iller; --Where ILId=@ILId;", null).Tables[0];
                dataGridView1.DataSource = dT;

                stpwtch.Stop();
                MessageBox.Show(String.Format("Geçen Zaman : {0}", stpwtch.ElapsedMilliseconds));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnGetFromAccess_Click(object sender, EventArgs e)
        {
            Stopwatch stpwtch = new Stopwatch(); stpwtch.Start();
            OleDbManager oledbMan = new OleDbManager(
                @"Provider=Microsoft.Jet.Oledb.4.0;Data Source=D:\E\Yazılım\CSharp\CShap.Kod.Ornek.Uyg\Uygulamalar\Calisan Uygulamalar\ILLER\IllerUygulaması\IllerUygulaması\bin\Debug\dbofl;User Id=admin;Jet OLEDB:Database Password=DilkiDepesi"
                /*
@"Provider=Microsoft.Jet.Oledb.4.0;
Data Source=D:\E\Yazılım\CSharp\CShap.Kod.Ornek.Uyg\Uygulamalar\Calisan Uygulamalar\FilmArşivi\film arsivi\WindowsApplication1\bin\Debug\indexim.mdb"*/
                );

            dataGridView1.DataSource = oledbMan.GetResultSetOfQuery(
                @"Select * from iller;"
                //"Select count(dvd),tur from indexim group by tur"
                ).Tables[0];
            stpwtch.Stop();
            MessageBox.Show(String.Format("Geçen Zaman : {0}", stpwtch.ElapsedMilliseconds));
        }
    }
}

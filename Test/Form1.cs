using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Test
{

    public partial class Form1 : Form
    {
        private AppSettings myAppSettings;
       // private System.Windows.Forms.PropertyGrid propertyGrid1;

        public Form1()
        {
            InitializeComponent();
            myAppSettings = new AppSettings();
            propertyGrid1.SelectedObject =  myAppSettings;

//descriptor_type: AVB_INTERFACE
//descriptor_index: 0
//object_name = en0
//localized_description = 65535
//mac_address = 0x0x22970405b7
//interface_flags = 0x0x7
//clock_identity = 0x0x2297fffe0405b7
//priority1 = 0
//clock_class = 1
//offset_scaled_log_variance = 17258
//clock_accuracy = 32
//priority2 = 248
//domain_number = 0
//log_sync_interval = 253
//log_announce_interval = 0
//log_pdelay_interval = 0
//port_number = 1



        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.Write("Hello \n");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //TestClassクラスのTypeオブジェクトを取得する
            //Type t = typeof(Test.TestClass);
            Type t = typeof(Test.testStrutct);

            //メンバを取得する
            MemberInfo[] members = t.GetMembers(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.DeclaredOnly);
            foreach (MemberInfo m in members)
            {
                //メンバの型と、名前を表示する
                Console.WriteLine("{0} - {1} - {2}", m.MemberType, m.DeclaringType, m.Name);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }

    public class AppSettings
    {
        // プロパティの値を格納する変数
        private FormWindowState myWindowState;
        private Color myBackColor;

        // コンストラクタでプロパティの値を初期化
        public AppSettings()
        {
            myWindowState = FormWindowState.Normal;
            myBackColor = SystemColors.Window;
        }

        // ウィンドウの表示状態を設定するプロパティ
        public FormWindowState WindowState
        {
            get { return myWindowState; }
            set { myWindowState = value; }
        }

        // ウィンドウの背景色を設定するプロパティ
        public Color BackColor
        {
            get { return myBackColor; }
            set { myBackColor = value; }
        }
    }

    public struct testStrutct
    {
        int num;
        string name;
    };

    public class TestClass
    {

        testStrutct tmp;

        //列挙型
        public enum PublicEnum
        {
            One,
            Two,
        }

        //フィールド
        private int PrivateField;

        //プロパティ
        public int PublicProperty
        {
            get
            {
                return PrivateField;
            }
        }

        //コンストラクタ
        public TestClass(int val)
        {
            PrivateField = val;
        }

        //メソッド
        public string PublicMethod(string str)
        {
            str = "PublicMethodが呼び出されました。" + str;
            return str;
        }
        public string PublicMethod()
        {
            return PublicMethod("");
        }
    }


}

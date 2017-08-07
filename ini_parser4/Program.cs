using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ini_parser4
{
    class Program
    {
        static void ini_read_test()
        {
            var obj = new Profile();
            obj.Open(@"C:\Users\Makoto Harada\Downloads\sample.ini");
            string Key1 = obj.GetProfileValue("Section1", "Key1");
            string Key2 = obj.GetProfileValue("Section1", "Key2");
            string Key3 = obj.GetProfileValue("Section1", "Key3");
            string Key4 = obj.GetProfileValue("Section2", "Key4");
            Debug.WriteLine(Key1);
            Debug.WriteLine(Key2);
            Debug.WriteLine(Key3);
            Debug.WriteLine(Key4);
            obj.DumpProfile();
            //Console.WriteLine(Key1);
            //Console.ReadLine();
        }
        static void ini_write_test()
        {
            var obj = new Profile();
            obj.Open(@"C:\Users\Makoto Harada\Downloads\sample_write.ini");
            obj.SetProfileValue("TEST", "parent", "makoto");
            obj.SetProfileValue("TEST", "parent2", "eri");
            obj.SetProfileValue("KIDS", "son", "yamato");
            obj.SetProfileValue("KIDS", "son2", "shota");
            obj.WriteProfile();
            obj.DumpProfile();
        }

        static void ini_write_test_non_section()
        {
            var obj = new Profile();
            obj.Open(@"C:\Users\Makoto Harada\Downloads\sample_write2.ini");
            obj.SetProfileValue(Profile.NOSECTION, "parent", "makoto");
            obj.SetProfileValue(Profile.NOSECTION, "parent2", "eri");
            obj.SetProfileValue(Profile.NOSECTION, "son", "yamato");
            obj.SetProfileValue(Profile.NOSECTION, "son2", "shota");
            obj.WriteProfile();
            obj.DumpProfile();
        }

        static void ini_read_test_non_section_lf()
        {
            var obj = new Profile();
            obj.Open(@"C:\Users\Makoto Harada\Downloads\neoECU.cfg");
            obj.DumpProfile();
        }

        static void Main(string[] args)
        {
            ini_read_test();
            ini_write_test();
            ini_write_test_non_section();
            ini_read_test_non_section_lf();
        }
    }
}


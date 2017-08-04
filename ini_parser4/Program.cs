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
            //Console.WriteLine(Key1);
            //Console.ReadLine();
        }
        static void ini_write_test()
        {
            var obj = new Profile();
            obj.Open(@"C:\Users\Makoto Harada\Downloads\sample_write.ini");
            obj.SetProfileValue("TEST", "parent1", "makoto");
            obj.SetProfileValue("TEST", "paraent2", "eri");
            obj.SetProfileValue("KIDS", "son", "yamato");
            obj.SetProfileValue("KIDS", "son2", "shota");
            obj.WriteProfile();
        }

        static void ini_write_test_non_section()
        {
            var obj = new Profile();
            obj.Open(@"C:\Users\Makoto Harada\Downloads\sample_write2.ini");
            obj.SetProfileValue(null, "parent1", "makoto");
            obj.SetProfileValue(null, "paraent2", "eri");
            obj.SetProfileValue(null, "son", "yamato");
            obj.SetProfileValue(null, "son2", "shota");
            obj.WriteProfile();
        }

        static void Main(string[] args)
        {
            //ini_read_test();
            //ini_write_test();
            ini_write_test_non_section();

        }
    }
}


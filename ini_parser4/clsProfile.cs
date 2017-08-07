using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ini_parser4
{
    /****************************************************V
        * @file clsProfile.cs
        * @brief Profile I/O Stream
        * @auhor Sebastian
        * @date 2009/5/7
        * @version 1.0
        *****************************************************************************/

    using System;
    using System.Text;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml;

    ///////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Profileの読書を行うClass
    /// </summary>
    /// <remarks>
    /// ProfileのFile pathはClassのInstance化時に引数として行います。<br/>
    /// Instance化時にProfileの内容はConstructor内にてHashtableとして格納され
    /// 以下のMethodにて編集を行います。<br/>
    /// ・GetProfileValue  …指定したProfileKeyを変更します。<br/>
    /// ・WriteProfile    …ProfileをDISKに保存します。<br/>
    /// ・WriteXmlStrem    …ProfileをXMLに変換しDISKに保存します。<br/>
    /// </remarks>
    ///////////////////////////////////////////////////////////////////////////
    public class Profile
    {
        private Hashtable htProfile = new Hashtable(); // Profile保管用
        private string strBuffer;      // File読込用Buffer
        private string ProfileName = null;
        private FileIO FileIO = new FileIO();
        public const string NOSECTION = "NoSection";

        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ProfStreemのConstructor
        /// </summary>
        /// <param name="FilePath">ProfileのPathを指定</param>
        /// <remarks>
        /// 引数：<paramref name="FilePath"/>にて指定したProfineを読み込み
        /// HashTableに格納します。
        /// </remarks>
        ///////////////////////////////////////////////////////////////////////
        public int Open(string FilePath)
        {
            /******************************************************************
                * 変数宣言
                *****************************************************************/
            string strLine;       // 行取得用
            string strSectionName;     // SECTION名格納用
            string strKeyName;      // KEY名格納用
            string strKeyValue;      // 値格納用
            string[] strArray;      // Profile行単位格納用

            Hashtable htSection = new Hashtable(); // SECTION用Hashtable

            /******************************************************************
                * Section に属さないkeyとvalueは"NoSection" Section に格納
                *****************************************************************/
            strSectionName = NOSECTION;
            htProfile.Add(strSectionName, new Hashtable());
            htSection = (Hashtable)htProfile[strSectionName];

            /******************************************************************
                * 対象ファイルが存在しない場合は新規作成
                *****************************************************************/
            if (File.Exists(FilePath) == false)
            {
                FileIO.NewFile(FilePath);
                ProfileName = FilePath;
                return 0;
            }
            /******************************************************************
                * 対象ファイルを読込
                *****************************************************************/
            ProfileName = FilePath;
            strBuffer = FileIO.FileRead(FilePath);
            // 改行コードで切り分けて配列に格納
            strArray = strBuffer.Split('\n');
            /******************************************************************
                * 読み込んだ内容をHashTableに格納
                *****************************************************************/
            // Profileの内容をHashTableに格納
            foreach (string value in strArray)
            {
                strLine = value.Trim();
                if (strLine.Length > 0)
                {
                    /**********************************************************
                        * SECTION格納
                        *********************************************************/
                    if ((strLine.StartsWith("[") && strLine.EndsWith("]")))
                    {
                        // SECTION名取得
                        strSectionName = strLine.Substring(1, strLine.Length - 2);
                        // SECTIONをHASHTABLEに追加
                        htProfile.Add(strSectionName, new Hashtable());
                        // SECTION用HASHTABLEをINSTANCE化
                        htSection = (Hashtable)htProfile[strSectionName];
                    }
                    /**********************************************************
                        * KEY格納
                        *********************************************************/
                    else if (strLine.IndexOf('=') != -1)
                    {
                        // KEY名取得
                        strKeyName = strLine.Substring(0, value.IndexOf('='));
                        // KEY値取得
                        strKeyValue
                         = strLine.Substring(
                           strLine.IndexOf('=') + 1
                            , strLine.Length - strLine.IndexOf("=") - 1);
                        // 行末[#]コメント削除
                        if ((strKeyValue.IndexOf("#") != -1))
                        {
                            strKeyValue
                             = strKeyValue.Substring(0
                                 , strKeyValue.IndexOf("#"));
                        }
                        // 行末[;]コメント削除
                        if ((strKeyValue.IndexOf(";") != -1))
                        {
                            strKeyValue
                             = strKeyValue.Substring(0
                                 , strKeyValue.IndexOf(";"));
                        }
                        strKeyValue = strKeyValue.Trim();
                        // KEYをHASHTABLEに追加
                        htSection.Add(strKeyName, strKeyValue);
                    }
                    /**********************************************************
                        * 行頭COMMENT処理
                        *********************************************************/
                    else if (strLine.StartsWith("#")
                          || strLine.StartsWith(";"))
                    {
                    }
                }
            }
            dump_htProfile();

            return 0;
        }
        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Profileの値を取得します
        /// </summary>
        /// <param name="Section">取得するSECTION名を指定</param>
        /// <param name="Key">取得するKEYを指定</param>
        /// <returns>取得した値を返却します</returns>
        /// <remarks>
        /// <paramref name="Section"/>と<paramref name="Key"/>を指定し
        /// 対応するProfileの値を取得します。
        /// </remarks>
        /// <exception cref="System.Exception">
        /// <paramref name="Section"/>/<paramref name="Key"/>に対応する値が
        /// 存在しない場合は無条件に<c>null</c>を返却します。
        /// </exception>
        ///////////////////////////////////////////////////////////////////////
        public string GetProfileValue(string Section, string Key)
        {
            if (htProfile.ContainsKey(Section))
            {
                Hashtable htSection = (Hashtable)htProfile[Section];
                if (htSection.ContainsKey(Key))
                {
                    return (string)htSection[Key];
                }
            }
            return null;
        }
        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Profileに値を書き込みます。
        /// </summary>
        /// <param name="Section">書き込むSECTION名を指定</param>
        /// <param name="Key">書き込むKEYを指定</param>
        /// <param name="Value">書き込む値を指定します</param>
        /// <remarks>
        /// <paramref name="Section"/>と<paramref name="Key"/>に対応する値を
        /// 書き込みます。
        /// 既に<paramref name="Section"/>が存在する場合は、
        /// <paramref name="Section"/>の最終行に
        /// 新規に<paramref name="Key"/>の追加を行い<paramref name="Value"/>に
        /// 指定された値を書き込みます。
        /// <paramref name="Section"/>／<paramref name="Key"/>が共に存在する
        /// 場合は<paramref name="Value"/>で指定された値を上書きします。
        /// <paramref name="Section"/>／<paramref name="Key"/>が共に存在しない
        /// 場合はProfile上に新規に<paramref name="Section"/>と
        /// <paramref name="Key"/>を作成し<paramref name="Value"/>の値を
        /// 書き込みます。
        /// </remarks>
        ///////////////////////////////////////////////////////////////////////

        enum OVERWRITE
        {
            NEW,
            SEC,
            SEC_KEY,
        };

        public void SetProfileValue(string Section
                            , string Key
                            , string Value)
        {
            // SECTIONの有無を確認
            if (htProfile.ContainsKey(Section))
            {
                Hashtable htSection = (Hashtable)htProfile[Section];
                htSection[Key] = Value;
            }
            else
            {
                htProfile.Add(Section, new Hashtable());
                Hashtable htSection = (Hashtable)htProfile[Section];
                htSection.Add(Key, Value);
            }
        }

        void dump_htProfile()
        {
            Debug.WriteLine("--- dump_htProfile ----");

            foreach (string section in htProfile.Keys)
            {

                Debug.WriteLine(section);

                Hashtable htSection = (Hashtable)htProfile[section];
                // Key and value
                foreach (string key in htSection.Keys)
                    Debug.WriteLine(key + ": " + htSection[key]);
            }

        }

        void conv_section_to_string(string section, ref string Buffer)
        {
            Hashtable htSection = (Hashtable)htProfile[section];

            // Key and value
            foreach (string key in htSection.Keys)
                Buffer += key + "=" + htSection[key] + "\r\n";
        }

        // Convert htProfile key and values to strings
        string conv_hashtable_to_string(Hashtable htProfile)
        {
            string Buffer = "";

            foreach (string section in htProfile.Keys)
            {
                if (section == NOSECTION) {
                    Hashtable htSection = (Hashtable)htProfile[section];
                    if (htSection.Count > 0)
                    {
                        // setion header はなし
                        conv_section_to_string(NOSECTION, ref Buffer);
                    }
                    continue;
                }

                Buffer += "[" + section + "]\r\n";
                conv_section_to_string(section, ref Buffer);
            }

            return Buffer;
        }

        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Profileの書き込み
        /// </summary>
        /// <returns>実行の成否を返却</returns>
        /// <remarks>
        /// <seealso cref="Profile"/>にて読み込んだProfileを
        /// ファイルに書き込みます。
        /// </remarks>
        ///////////////////////////////////////////////////////////////////////
        public long WriteProfile()
        {
            try
            {
                string Buffer = conv_hashtable_to_string(htProfile);
                FileIO.FileWrite(ProfileName, Buffer, false);
                return 0;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ProfileをXml形式にて書き込みます。
        /// </summary>
        /// <param name="FilePath">XML FileのPath</param>
        /// <param name="RootElement">XMLのRootElmentを指定</param>
        /// <returns>
        /// 書き込みの成否を返却<br />
        /// <list type="number">
        /// <item>
        /// <description>0</description>
        /// 正常終了
        /// </item>
        /// <item>
        /// <description>-1</description>
        /// 書き込みに失敗
        /// </item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// 読み込んだProfileの値をXMLにて書き出します。
        /// </remarks> 
        ///////////////////////////////////////////////////////////////////////
        public long WriteXmlStream(string FilePath, string RootElement)
        {
            try
            {
                XmlTextWriter XmlWriter
                    = new XmlTextWriter(FilePath
                                    , Encoding.UTF8);
                XmlWriter.Formatting = Formatting.Indented;
                XmlWriter.WriteStartDocument(true);
                // RootElement出力
                XmlWriter.WriteStartElement(RootElement);
                foreach (string SectionName in htProfile.Keys)
                {
                    //SECTION名をStartElementとして出力
                    XmlWriter.WriteStartElement(SectionName);
                    Hashtable htSection = (Hashtable)htProfile[SectionName];
                    // KEYと値をELEMENTとして出力
                    foreach (string KeyName in htSection.Keys)
                    {
                        XmlWriter.WriteElementString(
                               KeyName
                             , (string)htSection[KeyName]
                               );
                    }
                    XmlWriter.WriteEndElement();
                }
                XmlWriter.WriteEndDocument();
                XmlWriter.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
    /// ///////////////////////////////////////////////////////////////////////
    /// <summary>
    /// File Input/Output Class
    /// </summary>
    /// ///////////////////////////////////////////////////////////////////////
    public class FileIO
    {
        private Encoding m_Encode;
        /// ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// FileIOのコンストラクタ
        /// </summary>
        /// ///////////////////////////////////////////////////////////////////
        public FileIO()
        {
            m_Encode = Encoding.GetEncoding("utf-8");
        }
        /// ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// Fileの文字Encodeを指定
        /// </summary>
        /// <value>文字列のEncoderを指定します。</value>
        /// <remarks>
        /// 指定できる文字コードは以下の通りです
        /// <list type="bullet">
        /// <item><description>shift_jis </description>日本語 (シフト JIS)</item>
        /// <item><description>IBM037 </description>IBM EBCDIC (米国 - カナダ)</item>
        /// <item><description>IBM437 </description>OEM 米国</item>
        /// <item><description>IBM500 </description>IBM EBCDIC (インターナショナル)</item>
        /// <item><description>ibm737 </description>ギリシャ語 (DOS)</item>
        /// <item><description>ibm775 </description>バルト言語 (DOS)</item>
        /// <item><description>ibm850 </description>西ヨーロッパ語 (DOS)</item>
        /// <item><description>ibm852 </description>中央ヨーロッパ言語 (DOS)</item>
        /// <item><description>IBM855 </description>OEM キリル語</item>
        /// <item><description>ibm857 </description>トルコ語 (DOS)</item>
        /// <item><description>IBM860 </description>ポルトガル語 (DOS)</item>
        /// <item><description>ibm861 </description>アイスランド語 (DOS)</item>
        /// <item><description>IBM863 </description>フランス語 (カナダ)(DOS)</item>
        /// <item><description>IBM865 </description>ノルウェー語 (DOS)</item>
        /// <item><description>cp866 </description>キリル語 (DOS)</item>
        /// <item><description>ibm869 </description>ギリシャ語 モダン (DOS)</item>
        /// <item><description>windows-874 </description>タイ語 (Windows)</item>
        /// <item><description>cp875 </description>IBM EBCDIC (ギリシャ語 モダン)</item>
        /// <item><description>shift_jis </description>日本語 (シフト JIS)</item>
        /// <item><description>gb2312 </description>簡体字中国語 (GB2312)</item>
        /// <item><description>ks_c_5601-1987 </description>韓国語</item>
        /// <item><description>big5 </description>繁体字中国語 (Big5)</item>
        /// <item><description>IBM1026 </description>IBM EBCDIC (トルコ語 Latin-5)</item>
        /// <item><description>utf-16 </description>Unicode</item>
        /// <item><description>unicodeFFFE </description>Unicode (Big-Endian)</item>
        /// <item><description>windows-1250 </description>中央ヨーロッパ言語 (Windows)</item>
        /// <item><description>windows-1251 </description>キリル語 (Windows)</item>
        /// <item><description>Windows-1252 </description>西ヨーロッパ言語 (Windows)</item>
        /// <item><description>windows-1253 </description>ギリシャ語 (Windows)</item>
        /// <item><description>windows-1254 </description>トルコ語 (Windows)</item>
        /// <item><description>windows-1255 </description>ヘブライ語 (Windows)</item>
        /// <item><description>windows-1256 </description>アラビア語 (Windows)</item>
        /// <item><description>windows-1257 </description>バルト語 (Windows)</item>
        /// <item><description>windows-1258 </description>ベトナム語 (Windows)</item>
        /// <item><description>Johab </description>韓国語 (Johab)</item>
        /// <item><description>macintosh </description>西ヨーロッパ言語 (Mac)</item>
        /// <item><description>x-mac-japanese </description>日本語 (Mac)</item>
        /// <item><description>x-mac-chinesetrad </description>繁体字中国語 (Mac)</item>
        /// <item><description>x-mac-korean </description>韓国語 (Mac)</item>
        /// <item><description>x-mac-greek </description>ギリシャ語 (Mac)</item>
        /// <item><description>x-mac-cyrillic </description>キリル語 (Mac)</item>
        /// <item><description>x-mac-chinesesimp </description>簡体字中国語 (Mac)</item>
        /// <item><description>x-mac-romanian </description>ルーマニア語 (Mac)</item>
        /// <item><description>x-mac-ukrainian </description>ウクライナ語 (Mac)</item>
        /// <item><description>x-mac-ce </description>中央ヨーロッパ語 (Mac)</item>
        /// <item><description>x-mac-icelandic </description>アイスランド語 (Mac)</item>
        /// <item><description>x-mac-turkish </description>トルコ語 (Mac)</item>
        /// <item><description>x-mac-croatian </description>クロアチア語 (Mac)</item>
        /// <item><description>x-Chinese-CNS </description>繁体字中国語 (CNS)</item>
        /// <item><description>us-ascii </description>US-ASCII</item>
        /// <item><description>x-cp20261 </description>T.61</item>
        /// <item><description>IBM290 </description>IBM EBCDIC (日本語カタカナ)</item>
        /// <item><description>koi8-r </description>キリル語 (KOI8-R)</item>
        /// <item><description>EUC-JP </description>日本語 (JIS 0208-1990 and 0212-1990)</item>
        /// <item><description>x-cp20936 </description>簡体字中国語 (GB2312-80)</item>
        /// <item><description>x-cp20949 </description>韓国語 Wansung</item>
        /// <item><description>x-cp21027 </description>Ext Alpha Lowercase</item>
        /// <item><description>koi8-u </description>キリル語 (KOI8-R)</item>
        /// <item><description>iso-8859-1 </description>西ヨーロッパ言語 (ISO)</item>
        /// <item><description>iso-8859-2 </description>中央ヨーロッパ言語 (ISO)</item>
        /// <item><description>iso-8859-4 </description>バルト語 (ISO)</item>
        /// <item><description>iso-8859-5 </description>キリル語 (ISO)</item>
        /// <item><description>iso-8859-7 </description>ギリシャ語 (ISO)</item>
        /// <item><description>iso-8859-9 </description>トルコ語 (ISO)</item>
        /// <item><description>iso-8859-13 </description>エストニア語 (ISO)</item>
        /// <item><description>iso-8859-15 </description>ラテン語 9 (ISO)</item>
        /// <item><description>iso-2022-jp </description>日本語 (JIS)</item>
        /// <item><description>csISO2022JP </description>日本語 (JIS-Allow 1 byte Kana)</item>
        /// <item><description>iso-2022-jp </description>日本語 (JIS-Allow 1 byte Kana - SO/SI)</item>
        /// <item><description>iso-2022-kr </description>韓国語 (ISO)</item>
        /// <item><description>x-cp50227 </description>簡体字中国語 (ISO-2022)</item>
        /// <item><description>euc-jp </description>日本語 (EUC)</item>
        /// <item><description>EUC-CN </description>簡体字中国語 (EUC)</item>
        /// <item><description>euc-kr </description>韓国語 (EUC)</item>
        /// <item><description>hz-gb-2312 </description>簡体字中国語 (HZ)</item>
        /// <item><description>GB18030 </description>簡体字中国語 (GB18030)</item>
        /// <item><description>utf-7 </description>Unicode (UTF-7)</item>
        /// <item><description>utf-8 </description>Unicode (UTF-8)</item>
        /// </list>
        /// </remarks>
        /// ///////////////////////////////////////////////////////////////////
        public string Encode
        {
            get
            {
                return m_Encode.WebName;
            }
            set
            {
                m_Encode = Encoding.GetEncoding(value);
            }
        }
        /// ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// ファイルの読み込み
        /// </summary>
        /// <param name="FilePath">読み込むファイルパスを指定します。</param>
        /// <returns>ファイルの内容をstringにて返却します。</returns>
        /// ///////////////////////////////////////////////////////////////////
        public string FileRead(string FilePath)
        {
            try
            {
                StreamReader Reader;
                string Buffer;
                /**************************************************************
                    * ファイルの有無を確認
                    *************************************************************/
                if (!File.Exists(FilePath))
                {
                    Debug.WriteLine(Path.GetFileName(FilePath) + " not found");
                    return default(string);
                }
                Reader = new StreamReader(FilePath, m_Encode);
                Buffer = Reader.ReadToEnd();
                Reader.Close();
                return Buffer;
            }
            catch (InvalidCastException e)
            {
                Debug.WriteLine(e.Message);
                throw (e);
            }
        }
        /// ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// ファイルの書き込み
        /// </summary>
        /// <param name="FilePath">ファイルのパスを指定</param>
        /// <param name="Buffer">書き込む内容を指定</param>
        /// <param name="Append">追記(false)/上書き(true)指定</param>
        /// <returns>書き込み成功時は0を返却</returns>
        /// <remarks>
        /// <paramref name="FilePath"/>に指定したファイルに
        /// <paramref name="Buffer"/>の内容を書き込みます。
        /// この際、<paramref name="Append"/>にTrueを指定した場合は
        /// 追記され、Falseを指定した場合は上書きが行われます。
        /// また、書き込み先のファイルが存在しない場合は
        /// 指定したファイルのパスに新たにファイルを作成し書き込みを行います。
        /// </remarks>
        /// ///////////////////////////////////////////////////////////////////
        public int FileWrite(string FilePath
                           , string Buffer
                           , bool Append)
        {
            try
            {
                int Size;
                StreamWriter Writer;
                Size = Buffer.Length;
                Writer = new StreamWriter(FilePath, Append, m_Encode, Size);
                Writer.Write(Buffer);
                Writer.Close();
                return 0;
            }
            catch (InvalidCastException e)
            {
                Debug.WriteLine(e.Message);
                throw (e);
            }
        }
        /// ///////////////////////////////////////////////////////////////////
        /// <summary>
        /// ファイルの新規作成
        /// </summary>
        /// <param name="FilePath">作成するファイルのパスを指定</param>
        /// <returns>
        /// 作成されたファイルのFileStreamオブジェクトを返却します。
        /// </returns>
        /// ///////////////////////////////////////////////////////////////////
        public void NewFile(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                return;
            }
            File.Create(FilePath).Close();
        }
    }
}

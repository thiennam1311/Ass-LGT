using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S_DES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button tạo key random
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandomkey_Click(object sender, EventArgs e)
        {
            string key = "";
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int value = rand.Next(0, 2);
                key += value.ToString();
            }
            key.Trim();
            txtBoxKey.Text = key;
        }
        /// <summary>
        /// Button mã hóa file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string strPlaintext_Path = "";
            string strCiphertext_Path = "";
            if (txtBoxInput.Text == "")
                strPlaintext_Path = AppDomain.CurrentDomain.BaseDirectory + "/plaintext.txt";
            else strPlaintext_Path = txtBoxInput.Text;

            if (txtBoxOutput.Text == "")
                strCiphertext_Path = AppDomain.CurrentDomain.BaseDirectory + "/result_ciphertext.txt";
            else strCiphertext_Path = txtBoxOutput.Text;
            // List chứa key
            List<int> lstKey = new List<int>();
            // List chứa text chuyển qua dạng binary
            List<int> lstBinaryInput = new List<int>();
            // Kiểm tra key đúng định dạng hay không 
            if (txtBoxKey.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Key not empty.");
                return;
            }
            else if (txtBoxKey.Text.ToString().Trim().Length != 10)
            {
                MessageBox.Show("Key incorrectly format.");
                return;
            }
            // Lấy key từ textBox
            string strKey = txtBoxKey.Text;
            //Chuyển string key qua List key
            foreach (var item in strKey)
            {
                string temp = item.ToString();
                lstKey.Add(Convert.ToInt32(temp));
            }
            //Đọc bytes từ file cần mã hóa
            byte[] readbytes = System.IO.File.ReadAllBytes(strPlaintext_Path);
            //Ghi file từ mảng byte
            byte[] writebytes;
            // Chuyển bytes qua dạng binary
            foreach (var item in readbytes)
            {
                string binary = Convert.ToString(item, 2).PadLeft(8, '0');

                for (int i = 0; i < 8; i++)
                {
                    int temp = Convert.ToInt32(binary[i].ToString());
                    lstBinaryInput.Add(temp);
                }
            }
            // Chuyển Key qua dạng P10
            List<int> lstP10Key = Permutaion10(lstKey);
            //Chuyển key qua dạng LS1
            List<int> lstLS1Key = LeftShift(lstP10Key);
            //Chuyển key qua dạng LS2
            List<int> lstLS2Key = LeftShift(LeftShift(lstLS1Key));
            //SubKey1 P8 LS1
            List<int> lstP8KeyLS1 = Permutaion8(lstLS1Key);
            //SubKey2 P8 LS2
            List<int> lstP8KeyLS2 = Permutaion8(lstLS2Key);
            //IP đầu vào
            List<int> lstBinaryfK = new List<int>();
            List<byte> lstBytes = new List<byte>();
            for (int i = 0; i < lstBinaryInput.Count / 8; i++)
            {
                List<int> lstTemp = new List<int>(8);
                for (int j = 0; j < 8; j++)
                {
                    lstTemp.Add(lstBinaryInput.ElementAt(i * 8 + j));
                }
                lstTemp = InitialPermutation(lstTemp);
                lstTemp = fK(lstTemp, lstP8KeyLS1);
                lstTemp = SW(lstTemp);
                lstTemp = fK(lstTemp, lstP8KeyLS2);
                lstTemp = InitialPermutation_1(lstTemp);
                string binary = "";
                for (int j = 0; j < 8; j++)
                {
                    //lstBinaryfK.Add(lstTemp.ElementAt(j));
                    binary += lstTemp.ElementAt(j).ToString();
                }
                byte temp = Convert.ToByte(binary, 2);
                lstBytes.Add(temp);
            }
            writebytes = lstBytes.ToArray();
            System.IO.File.WriteAllBytes(strCiphertext_Path, writebytes);
            //Convert list binary to bytes and write to file
            MessageBox.Show("Encryption successful.");
        }
        /// <summary>
        /// Button giải mã file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string strPlaintext_Path = "";
            string strCiphertext_Path = "";
            if (txtBoxOutput.Text == "")
                strPlaintext_Path = AppDomain.CurrentDomain.BaseDirectory + "/plaintext.txt";
            else strPlaintext_Path = txtBoxInput.Text;

            if (txtBoxInput.Text == "")
                strCiphertext_Path = AppDomain.CurrentDomain.BaseDirectory + "/result_ciphertext.txt";
            else strCiphertext_Path = txtBoxOutput.Text;
            // List chứa key
            List<int> lstKey = new List<int>();
            // List chứa text chuyển qua dạng binary
            List<int> lstBinaryInput = new List<int>();
            // Kiểm tra key đúng định dạng hay không 
            if (txtBoxKey.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Key not empty.");
                return;
            }
            else if (txtBoxKey.Text.ToString().Trim().Length != 10)
            {
                MessageBox.Show("Key incorrectly format.");
                return;
            }
            // Lấy key từ textBox
            string strKey = txtBoxKey.Text;
            //Chuyển string key qua List key
            foreach (var item in strKey)
            {
                string temp = item.ToString();
                lstKey.Add(Convert.ToInt32(temp));
            }
            //Đọc bytes từ file cần mã hóa
            byte[] readbytes = System.IO.File.ReadAllBytes(strCiphertext_Path);
            //Ghi file từ mảng byte
            byte[] writebytes;
            // Chuyển bytes qua dạng binary
            foreach (var item in readbytes)
            {
                string binary = Convert.ToString(item, 2).PadLeft(8, '0');

                for (int i = 0; i < 8; i++)
                {
                    int temp = Convert.ToInt32(binary[i].ToString());
                    lstBinaryInput.Add(temp);
                }
            }
            // Chuyển Key qua dạng P10
            List<int> lstP10Key = Permutaion10(lstKey);
            //Chuyển key qua dạng LS1
            List<int> lstLS1Key = LeftShift(lstP10Key);
            //Chuyển key qua dạng LS2
            List<int> lstLS2Key = LeftShift(LeftShift(lstLS1Key));
            //SubKey1 P8 LS1
            List<int> lstP8KeyLS1 = Permutaion8(lstLS1Key);
            //SubKey2 P8 LS2
            List<int> lstP8KeyLS2 = Permutaion8(lstLS2Key);
            //IP đầu vào
            List<int> lstBinaryfK = new List<int>();
            List<byte> lstBytes = new List<byte>();
            for (int i = 0; i < lstBinaryInput.Count / 8; i++)
            {
                List<int> lstTemp = new List<int>(8);
                for (int j = 0; j < 8; j++)
                {
                    lstTemp.Add(lstBinaryInput.ElementAt(i * 8 + j));
                }
                lstTemp = InitialPermutation(lstTemp);
                lstTemp = fK(lstTemp, lstP8KeyLS2);
                lstTemp = SW(lstTemp);
                lstTemp = fK(lstTemp, lstP8KeyLS1);
                lstTemp = InitialPermutation_1(lstTemp);
                string binary = "";
                for (int j = 0; j < 8; j++)
                {
                    //lstBinaryfK.Add(lstTemp.ElementAt(j));
                    binary += lstTemp.ElementAt(j).ToString();
                }
                byte temp = Convert.ToByte(binary, 2);
                lstBytes.Add(temp);
            }
            writebytes = lstBytes.ToArray();
            System.IO.File.WriteAllBytes(strPlaintext_Path, writebytes);
            //Convert list binary to bytes and write to file
            MessageBox.Show("Decryption successful.");
        }
        public string ReadFile(string pathFile)
        {
            StringBuilder strAllText = new StringBuilder();
            byte[] arrBytes = System.IO.File.ReadAllBytes(pathFile);
            foreach (var item in arrBytes)
            {
                strAllText.Append(Convert.ToString(item, 2).PadLeft(8, '0'));
            }
            return strAllText.ToString();
        }
        /// <summary>
        /// Permutation 10
        /// </summary>
        /// <param name="lstKey">List chứa khóa k</param>
        /// <returns>List chứa khóa sau khi hoán vị</returns>
        /// Hoán vị : 3 5 2 7 4 10 1 9 8 6
        public List<int> Permutaion10(List<int> lstKey)
        {

            List<int> lstTemp = new List<int>(10);
            lstTemp.Add(lstKey.ElementAt(2));
            lstTemp.Add(lstKey.ElementAt(4));
            lstTemp.Add(lstKey.ElementAt(1));
            lstTemp.Add(lstKey.ElementAt(6));
            lstTemp.Add(lstKey.ElementAt(3));
            lstTemp.Add(lstKey.ElementAt(9));
            lstTemp.Add(lstKey.ElementAt(0));
            lstTemp.Add(lstKey.ElementAt(8));
            lstTemp.Add(lstKey.ElementAt(7));
            lstTemp.Add(lstKey.ElementAt(5));
            return lstTemp;
        }
        /// <summary>
        /// Tạo khóa LS
        /// </summary>
        /// <param name="lstP10">List khóa P10</param>
        /// <param name="LSx">LSx = 1 or LSx = 2</param>
        /// <returns>Khóa sao khi dịch trái vòng x bit</returns>
        public List<int> LeftShift(List<int> lstP10)
        {
            List<int> lstTemp = new List<int>(10);
            for (int i = 0; i < 4; i++)
            {
                lstTemp.Add(lstP10.ElementAt(i + 1));
            }
            lstTemp.Add(lstP10.ElementAt(0));
            for (int i = 5; i < 9; i++)
            {
                lstTemp.Add(lstP10.ElementAt(i + 1));
            }
            lstTemp.Add(lstP10.ElementAt(5));

            return lstTemp;
        }
        /// <summary>
        /// Permutaion 8
        /// </summary>
        /// <param name="lstKeyLS">List sau khi dịch trái vòng x bit</param>
        /// <returns>Khóa con P8 </returns>
        /// Hoán vị : 6 3 7 4 8 5 10 9
        public List<int> Permutaion8(List<int> lstKeyLS)
        {
            List<int> lstTemp = new List<int>(8);
            lstTemp.Add(lstKeyLS.ElementAt(5));
            lstTemp.Add(lstKeyLS.ElementAt(2));
            lstTemp.Add(lstKeyLS.ElementAt(6));
            lstTemp.Add(lstKeyLS.ElementAt(3));
            lstTemp.Add(lstKeyLS.ElementAt(7));
            lstTemp.Add(lstKeyLS.ElementAt(4));
            lstTemp.Add(lstKeyLS.ElementAt(9));
            lstTemp.Add(lstKeyLS.ElementAt(8));
            return lstTemp;
        }
        /// <summary>
        /// Initial Permutation
        /// </summary>
        /// <param name="lstBinary"></param>
        /// <returns></returns>
        /// Hoán vị : 2 6 3 1 4 8 5 7
        public List<int> InitialPermutation(List<int> lstBinary)
        {
            List<int> lstTemp = new List<int>(8);
            lstTemp.Add(lstBinary.ElementAt(1));
            lstTemp.Add(lstBinary.ElementAt(5));
            lstTemp.Add(lstBinary.ElementAt(2));
            lstTemp.Add(lstBinary.ElementAt(0));
            lstTemp.Add(lstBinary.ElementAt(3));
            lstTemp.Add(lstBinary.ElementAt(7));
            lstTemp.Add(lstBinary.ElementAt(4));
            lstTemp.Add(lstBinary.ElementAt(6));
            return lstTemp;
        }
        /// <summary>
        /// Initial Permulation -1
        /// </summary>
        /// <param name="lstBinary"></param>
        /// <returns></returns>
        /// Hoán vị : 4 1 3 5 7 2 8 6
        public List<int> InitialPermutation_1(List<int> lstBinary)
        {
            List<int> lstTemp = new List<int>(8);
            lstTemp.Add(lstBinary.ElementAt(3));
            lstTemp.Add(lstBinary.ElementAt(0));
            lstTemp.Add(lstBinary.ElementAt(2));
            lstTemp.Add(lstBinary.ElementAt(4));
            lstTemp.Add(lstBinary.ElementAt(6));
            lstTemp.Add(lstBinary.ElementAt(1));
            lstTemp.Add(lstBinary.ElementAt(7));
            lstTemp.Add(lstBinary.ElementAt(5));
            return lstTemp;
        }

        public List<int> Exclusive_OR(List<int> lstInput, List<int> lstKey)
        {
            List<int> lstOutput = new List<int>();
            for (int i = 0; i < lstInput.Count; i++)
            {
                if (lstInput[i] == lstKey[i])
                {
                    lstOutput.Add(0);
                }
                else lstOutput.Add(1);
            }
            return lstOutput;
        }
        public List<int> ExpansionPermutation(List<int> lstInput)
        {
            List<int> lstOutput = new List<int>(8);
            lstOutput.Add(lstInput.ElementAt(3));
            lstOutput.Add(lstInput.ElementAt(0));
            lstOutput.Add(lstInput.ElementAt(1));
            lstOutput.Add(lstInput.ElementAt(2));
            lstOutput.Add(lstInput.ElementAt(1));
            lstOutput.Add(lstInput.ElementAt(2));
            lstOutput.Add(lstInput.ElementAt(3));
            lstOutput.Add(lstInput.ElementAt(0));
            return lstOutput;
        }
        public int getValue(int a, int b)
        {
            if (a == 0 && b == 0)
                return 0;
            else if (a == 0 && b == 1)
                return 1;
            else if (a == 1 && b == 0)
                return 2;
            else return 3;
        }
        public List<int> S_Box(List<int> lstInput)
        {
            List<int> lstOuput = new List<int>();
            int[][] S0 = {
                new int[]{1,0,3,2},
                new int[]{3,2,1,0},
                new int[]{0,2,1,3},
                new int[]{3,1,3,2}
            };
            int[][] S1 = {
                new int[]{0,1,2,3},
                new int[]{2,0,1,3},
                new int[]{3,0,1,0},
                new int[]{2,1,0,3}
            };

            int row, col;
            //Lấy hàng, cột 4 bit đầu
            row = getValue(lstInput.ElementAt(0), lstInput.ElementAt(3));
            col = getValue(lstInput.ElementAt(1), lstInput.ElementAt(2));
            if (S0[row][col] == 0)
            {
                lstOuput.Add(0);
                lstOuput.Add(0);
            }
            else if (S0[row][col] == 1)
            {
                lstOuput.Add(0);
                lstOuput.Add(1);
            }
            else if (S0[row][col] == 2)
            {
                lstOuput.Add(1);
                lstOuput.Add(0);
            }
            else
            {
                lstOuput.Add(1);
                lstOuput.Add(1);
            }
            //Lấy hàng cột 4 bit sau
            row = getValue(lstInput.ElementAt(4), lstInput.ElementAt(7));
            col = getValue(lstInput.ElementAt(5), lstInput.ElementAt(6));
            if (S1[row][col] == 0)
            {
                lstOuput.Add(0);
                lstOuput.Add(0);
            }
            else if (S1[row][col] == 1)
            {
                lstOuput.Add(0);
                lstOuput.Add(1);
            }
            else if (S1[row][col] == 2)
            {
                lstOuput.Add(1);
                lstOuput.Add(0);
            }
            else
            {
                lstOuput.Add(1);
                lstOuput.Add(1);
            }
            return lstOuput;
        }
        /// <summary>
        /// Permutation 4
        /// </summary>
        /// <param name="lstInput"></param>
        /// <returns></returns>
        /// Hoán vị : 2 4 3 1
        public List<int> Permutaion4(List<int> lstInput)
        {
            List<int> lstOuput = new List<int>(4);
            lstOuput.Add(lstInput.ElementAt(1));
            lstOuput.Add(lstInput.ElementAt(3));
            lstOuput.Add(lstInput.ElementAt(2));
            lstOuput.Add(lstInput.ElementAt(0));
            return lstOuput;
        }
        public List<int> fK(List<int> lstInput, List<int> lstKey)
        {
            List<int> lstOuput = new List<int>();
            List<int> left = new List<int>(4);
            List<int> right = new List<int>(4);
            List<int> EP_Right = new List<int>(8);
            List<int> S_Box_Right = new List<int>(4);
            for (int j = 0; j < 4; j++)
            {
                left.Add(lstInput.ElementAt(j));
                right.Add(lstInput.ElementAt(j + 4));
            }
            EP_Right = ExpansionPermutation(right);
            EP_Right = Exclusive_OR(EP_Right, lstKey);
            S_Box_Right = S_Box(EP_Right);
            S_Box_Right = Permutaion4(S_Box_Right);
            S_Box_Right = Exclusive_OR(left, S_Box_Right);
            for (int j = 0; j < 4; j++)
                lstOuput.Add(S_Box_Right.ElementAt(j));
            for (int j = 0; j < 4; j++)
                lstOuput.Add(right.ElementAt(j));

            return lstOuput;
        }
        /// <summary>
        /// Hoán vị 4 bit trái với 4 bit phải
        /// </summary>
        /// <param name="lstInput"></param>
        /// <returns></returns>
        /// Hoán vị : 5 6 7 8 1 2 3 4
        public List<int> SW(List<int> lstInput)
        {
            List<int> lstOutput = new List<int>();
            lstOutput.Add(lstInput.ElementAt(4));
            lstOutput.Add(lstInput.ElementAt(5));
            lstOutput.Add(lstInput.ElementAt(6));
            lstOutput.Add(lstInput.ElementAt(7));
            lstOutput.Add(lstInput.ElementAt(0));
            lstOutput.Add(lstInput.ElementAt(1));
            lstOutput.Add(lstInput.ElementAt(2));
            lstOutput.Add(lstInput.ElementAt(3));
            return lstOutput;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            DialogResult inputPath = openFileInput.ShowDialog();
            if (inputPath.ToString() == "OK")
            {
                txtBoxInput.Text = openFileInput.FileName;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            DialogResult outputPath = openFileInput.ShowDialog();
            if (outputPath.ToString() == "OK")
            {
                txtBoxOutput.Text = openFileInput.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

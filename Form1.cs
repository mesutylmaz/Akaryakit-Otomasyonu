using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akaryakıt_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double depodakiBenzin95 , depodakiBenzin97 , depodakiDizel , depodakiEuroDizel , depodakiLPG ;
        double eklenecekBenzin95 = 0, eklenecekBenzin97 = 0, eklenecekDizel = 0, eklenecekEuroDizel = 0, eklenecekLPG = 0;
        double fiyatBenzin95 = 0, fiyatBenzin97 = 0, fiyatDizel = 0, fiyatEuroDizel = 0, fiyatLPG = 0;
        double satilanBenzin95 = 0, satilanBenzin97 = 0, satilanDizel = 0, satilanEuroDizel = 0, satilanLPG = 0;

        
        string[] depoBilgileri;
        string[] fiyatBilgileri;


        protected void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "AKARYAKIT OTOMASYONU";
            prgBarDepoBenzin95.Maximum = 1000;
            prgBarDepoBenzin97.Maximum = 1000;
            prgBarDepoDizel.Maximum = 1000;
            prgBarDepoEuroDizel.Maximum = 1000;
            prgBarDepoLPG.Maximum = 1000;
            DepoOku();
            DepoYaz();
            FiyatOku();
            FiyatYaz();
            ProgressBarGuncelle();
            NumericUpDownValue();

            string[] yakitTurleri = { "Benzin(95)", "Benzin(97)", "Dizel", "Euro Dizel", "LPG" };
            cmbYakitTürü.Items.AddRange(yakitTurleri);
            nmrBenzin95.Enabled = false;
            nmrBenzin97.Enabled = false;
            nmrDizel.Enabled = false;
            nmrEuroDizel.Enabled = false;
            nmrLPG.Enabled = false;


            nmrBenzin95.DecimalPlaces = 2;  //Numeric ifadelerim virgülden sonra 2 basamak gösterilecek şekilde girilebilsin. 
            nmrBenzin97.DecimalPlaces = 2;  //Bu işlem, Property'den de manuel(kod yazmadan) yapılabilir.
            nmrDizel.DecimalPlaces = 2;
            nmrEuroDizel.DecimalPlaces = 2;
            nmrLPG.DecimalPlaces = 2;


            nmrBenzin95.Increment = 0.1M;   //Numeric ifadelerim her tıklandığında 0.1 artsın yada azalsın dedik.
            nmrBenzin97.Increment = 0.1M;   //Bu işlem, Property'den de manuel(kod yazmadan) yapılabilir.
            nmrDizel.Increment = 0.1M;
            nmrEuroDizel.Increment = 0.1M;
            nmrLPG.Increment = 0.1M;


            nmrBenzin95.ReadOnly = true;    //Numeric ifadelerime tıklamayla değil manuel giriş yapılmasını engelledim.
            nmrBenzin97.ReadOnly = true;    //Bu işlem, Property'den de manuel(kod yazmadan) yapılabilir.
            nmrDizel.ReadOnly = true;
            nmrEuroDizel.ReadOnly = true;
            nmrLPG.ReadOnly = true;
        }


        protected void btnDepoBilgileriniGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                eklenecekBenzin95 = Convert.ToDouble(txtDepoBenzin95.Text);
                if((1000< (depodakiBenzin95+eklenecekBenzin95))||eklenecekBenzin95<=0)
                {
                    txtDepoBenzin95.Text = "Hata";
                }
                else
                {
                    depoBilgileri[0] = Convert.ToString(depodakiBenzin95 + eklenecekBenzin95);
                    txtDepoBenzin95.Text = "";
                }
            }
            catch (Exception)
            {

                txtDepoBenzin95.Text = "Hata!";
            }
            try
            {
                eklenecekBenzin97 = Convert.ToDouble(txtDepoBenzin97.Text);
                if ((eklenecekBenzin97 + depodakiBenzin97) > 1000 || eklenecekBenzin97 <= 0)
                {
                    txtDepoBenzin97.Text = "Hata";
                }
                else
                {
                    depoBilgileri[1] = Convert.ToString(depodakiBenzin97 + eklenecekBenzin97);
                    txtDepoBenzin97.Text = "";
                }
            }
            catch (Exception)
            {

                txtDepoBenzin97.Text = "Hata!";
            }
            try
            {
                eklenecekDizel = Convert.ToDouble(txtDepoDizel.Text);
                if ((eklenecekDizel + depodakiDizel) > 1000 || eklenecekDizel <= 0)
                {
                    txtDepoDizel.Text = "Hata";
                }
                else
                {
                    depoBilgileri[2] = Convert.ToString(depodakiDizel + eklenecekDizel);
                    txtDepoDizel.Text = "";
                }
            }
            catch (Exception)
            {

                txtDepoDizel.Text = "Hata!";
            }
            try
            {
                eklenecekEuroDizel = Convert.ToDouble(txtDepoEuroDizel.Text);
                if ((eklenecekEuroDizel + depodakiEuroDizel) > 1000 || eklenecekEuroDizel <= 0)
                {
                    txtDepoEuroDizel.Text = "Hata";
                }
                else
                {
                    depoBilgileri[3] = Convert.ToString(depodakiEuroDizel + eklenecekEuroDizel);
                    txtDepoEuroDizel.Text = "";
                }
            }
            catch (Exception)
            {

                txtDepoEuroDizel.Text = "Hata!";
            }
            try
            {
                eklenecekLPG = Convert.ToDouble(txtDepoLPG.Text);
                if ((eklenecekLPG + depodakiLPG) > 1000 || eklenecekLPG <= 0)
                {
                    txtDepoLPG.Text = "Hata";
                }
                else
                {
                    depoBilgileri[4] = Convert.ToString(depodakiLPG + eklenecekLPG);
                    txtDepoLPG.Text = "";
                }
            }
            catch (Exception)
            {

                txtDepoLPG.Text = "Hata!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\Depo.txt", depoBilgileri);
            DepoOku();
            DepoYaz();
            ProgressBarGuncelle();
            NumericUpDownValue();
        }


        protected void btnFiyatBilgileriniGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                fiyatBenzin95 = fiyatBenzin95 + (fiyatBenzin95 + Convert.ToDouble(txtIndirimZamBenzin95.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(fiyatBenzin95);
            }
            catch (Exception)
            {
                txtIndirimZamBenzin95.Text = "Hata!";
                throw;
            }
            try
            {
                fiyatBenzin97 = fiyatBenzin97 + (fiyatBenzin97 + Convert.ToDouble(txtIndirimZamBenzin97.Text) / 100);
                fiyatBilgileri[1] = Convert.ToString(fiyatBenzin97);
            }
            catch (Exception)
            {
                txtIndirimZamBenzin97.Text = "Hata!";
                throw;
            }
            try
            {
                fiyatDizel = fiyatDizel + (fiyatDizel + Convert.ToDouble(txtIndirimZamDizel.Text) / 100);
                fiyatBilgileri[2] = Convert.ToString(fiyatDizel);
            }
            catch (Exception)
            {
                txtIndirimZamDizel.Text = "Hata!";
                throw;
            }
            try
            {
                fiyatEuroDizel = fiyatEuroDizel + (fiyatEuroDizel + Convert.ToDouble(txtIndirimZamEuroDizel.Text) / 100);
                fiyatBilgileri[3] = Convert.ToString(fiyatEuroDizel);
            }
            catch (Exception)
            {
                txtIndirimZamEuroDizel.Text = "Hata!";
                throw;
            }
            try
            {
                fiyatLPG = fiyatLPG + (fiyatLPG + Convert.ToDouble(txtIndirimZamLPG.Text) / 100);
                fiyatBilgileri[4] = Convert.ToString(fiyatLPG);
            }
            catch (Exception)
            {
                txtIndirimZamLPG.Text = "Hata!";
                throw;
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\Fiyat.txt", fiyatBilgileri);
            FiyatOku();
            FiyatYaz();
        }


        protected void cmbYakitTürü_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYakitTürü.Text == "Benzin(95)")
            {
                nmrBenzin95.Enabled = true;
                nmrBenzin97.Enabled = false;
                nmrDizel.Enabled = false;
                nmrEuroDizel.Enabled = false;
                nmrLPG.Enabled = false;
            }
            else if (cmbYakitTürü.Text == "Benzin(97)")
            {
                nmrBenzin95.Enabled = false;
                nmrBenzin97.Enabled = true;
                nmrDizel.Enabled = false;
                nmrEuroDizel.Enabled = false;
                nmrLPG.Enabled = false;
            }
            else if (cmbYakitTürü.Text == "Dizel")
            {
                nmrBenzin95.Enabled = false;
                nmrBenzin97.Enabled = false;
                nmrDizel.Enabled = true;
                nmrEuroDizel.Enabled = false;
                nmrLPG.Enabled = false;
            }
            else if (cmbYakitTürü.Text == "Euro Dizel")
            {
                nmrBenzin95.Enabled = false;
                nmrBenzin97.Enabled = false;
                nmrDizel.Enabled = false;
                nmrEuroDizel.Enabled = true;
                nmrLPG.Enabled = false;
            }
            else if (cmbYakitTürü.Text == "LPG")
            {
                nmrBenzin95.Enabled = false;
                nmrBenzin97.Enabled = false;
                nmrDizel.Enabled = false;
                nmrEuroDizel.Enabled = false;
                nmrLPG.Enabled = true;
            }
            nmrBenzin95.Value = 0;  //Numeric ifadelerimden birinde işlem yaptıtıktan sonra combo'dan başka bir yakıt türü seçince numariclerin içi 0'lansın.
            nmrBenzin97.Value = 0;
            nmrDizel.Value = 0;
            nmrEuroDizel.Value = 0;
            nmrLPG.Value = 0;
            lblOdenecekTutar.Text = "_______________";
        }


        protected void btnSatisYap_Click(object sender, EventArgs e)
        {
            satilanBenzin95 = double.Parse(nmrBenzin95.Value.ToString());
            satilanBenzin97 = double.Parse(nmrBenzin97.Value.ToString());
            satilanDizel = double.Parse(nmrDizel.Value.ToString());
            satilanEuroDizel = double.Parse(nmrEuroDizel.Value.ToString());
            satilanLPG = double.Parse(nmrLPG.Value.ToString());

            if (nmrBenzin95.Enabled)
            {
                depodakiBenzin95 = depodakiBenzin95 - satilanBenzin95;
                lblOdenecekTutar.Text = Convert.ToString(satilanBenzin95 * fiyatBenzin95);
            }
            else if (nmrBenzin97.Enabled)
            {
                depodakiBenzin97 = depodakiBenzin97 - satilanBenzin97;
                lblOdenecekTutar.Text = Convert.ToString(satilanBenzin97 * fiyatBenzin97);
            }
            else if (nmrDizel.Enabled)
            {
                depodakiDizel = depodakiDizel - satilanDizel;
                lblOdenecekTutar.Text = Convert.ToString(satilanDizel * fiyatDizel);
            }
            else if (nmrEuroDizel.Enabled)
            {
                depodakiEuroDizel = depodakiEuroDizel - satilanEuroDizel;
                lblOdenecekTutar.Text = Convert.ToString(satilanEuroDizel * fiyatEuroDizel);
            }
            else if (nmrLPG.Enabled)
            {
                depodakiLPG = depodakiLPG - satilanLPG;
                lblOdenecekTutar.Text = Convert.ToString(satilanLPG * fiyatLPG);
            }

            depoBilgileri[0] = Convert.ToString(depodakiBenzin95);
            depoBilgileri[1] = Convert.ToString(depodakiBenzin97);
            depoBilgileri[2] = Convert.ToString(depodakiDizel);
            depoBilgileri[3] = Convert.ToString(depodakiEuroDizel);
            depoBilgileri[4] = Convert.ToString(depodakiLPG);


            System.IO.File.WriteAllLines(Application.StartupPath + "\\Depo.txt", depoBilgileri);

            DepoOku();
            DepoYaz();
            ProgressBarGuncelle();
            NumericUpDownValue();

            nmrBenzin95.Value = 0;
            nmrBenzin97.Value = 0;
            nmrDizel.Value = 0;
            nmrEuroDizel.Value = 0;
            nmrLPG.Value = 0;
        }

        private void DepoOku()
        {
            depoBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\Depo.txt");    //Bin dosyasındaki(Application.StartUpPath) Depo metin belgemdeki verileri satır satır oku(ReadAllLines) ve depo bilgileri dizime ekle.
            depodakiBenzin95 = Convert.ToDouble(depoBilgileri[0]);
            depodakiBenzin97 = Convert.ToDouble(depoBilgileri[1]);
            depodakiDizel = Convert.ToDouble(depoBilgileri[2]);
            depodakiEuroDizel = Convert.ToDouble(depoBilgileri[3]);
            depodakiLPG = Convert.ToDouble(depoBilgileri[4]);
        }


        private void DepoYaz()
        {
            label2.Text = depodakiBenzin95.ToString("N");   //Virgülden sonraki basamak sayısı 2 olsun diye N yazdık.
            label3.Text = depodakiBenzin97.ToString("N");
            label5.Text = depodakiDizel.ToString("N");
            label7.Text = depodakiEuroDizel.ToString("N");
            label9.Text = depodakiLPG.ToString("N");
        }


        private void FiyatOku()
        {
            fiyatBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\Fiyat.txt");    //Bin dosyasındaki(Application.StartUpPath) Depo metin belgemdeki verileri satır satır oku(ReadAllLines) ve depo bilgileri dizime ekle.
            fiyatBenzin95 = Convert.ToDouble(fiyatBilgileri[0]);
            fiyatBenzin97 = Convert.ToDouble(fiyatBilgileri[1]);
            fiyatDizel = Convert.ToDouble(fiyatBilgileri[2]);
            fiyatEuroDizel = Convert.ToDouble(fiyatBilgileri[3]);
            fiyatLPG = Convert.ToDouble(fiyatBilgileri[4]);
        }


        private void FiyatYaz()
        {
            label19.Text = fiyatBenzin95.ToString("N");   //Virgülden sonraki basamak sayısı 2 olsun diye N yazdık.
            label17.Text = fiyatBenzin97.ToString("N");
            label15.Text = fiyatDizel.ToString("N");
            label13.Text = fiyatEuroDizel.ToString("N");
            label11.Text = fiyatLPG.ToString("N");
        }


        private void ProgressBarGuncelle()
        {
            prgBarDepoBenzin95.Value = Convert.ToInt16(depodakiBenzin95);
            prgBarDepoBenzin97.Value = Convert.ToInt16(depodakiBenzin97);
            prgBarDepoDizel.Value = Convert.ToInt16(depodakiDizel);
            prgBarDepoEuroDizel.Value = Convert.ToInt16(depodakiEuroDizel);
            prgBarDepoLPG.Value = Convert.ToInt16(depodakiLPG);
        }


        private void NumericUpDownValue()
        {
            nmrBenzin95.Maximum = decimal.Parse(depodakiBenzin95.ToString());
            nmrBenzin97.Maximum = decimal.Parse(depodakiBenzin97.ToString());
            nmrDizel.Maximum = decimal.Parse(depodakiDizel.ToString());
            nmrEuroDizel.Maximum = decimal.Parse(depodakiEuroDizel.ToString());
            nmrLPG.Maximum = decimal.Parse(depodakiLPG.ToString());
        }
    }
}

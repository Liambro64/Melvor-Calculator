namespace Melvor_Calculator
{
    public partial class Form1 : Form
    {
        public Form1() : base()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        float CompletionChance, timePerCompetion, expPerCompletion, targlev, exp;
        float TrueExpPerSecond, TotalCompletions;
        /// <summary>
        /// //////////////////
        /// </summary>
        /// <param name="t"></param>
        void add(Control t)
        {
            this.Controls.Add(t);

        }
        int i = 0;
        //used for exp
        TextBox t = new TextBox();
        TextBox TL= new TextBox();
        TextBox EPC= new TextBox();
        TextBox TPC= new TextBox();

        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l4 = new Label();
        Label l5 = new Label();
        Label l6 = new Label();
        Label l7 = new Label();
        private void Form1_Load(object sender, EventArgs e) {
            //1
            t.Location = new Point(100,50);
            t.BackColor = Color.LightGray;
            t.ForeColor = Color.DarkOliveGreen;
            t.AutoSize = true;
            t.Name = "enter EXP";
            t.Text = "";
            t.KeyPress += new KeyPressEventHandler(t_KeyPress);
            add(t);
            //2
            TL.Location = new Point(100, 100);
            TL.BackColor = Color.LightGray;
            TL.ForeColor = Color.DarkOliveGreen;
            TL.AutoSize = true;
            TL.Name = "enter Target level";
            TL.Text = "";
            TL.KeyPress += new KeyPressEventHandler(TL_KeyPress);
            add(TL);
            //3
            EPC.Location = new Point(100, 150);
            EPC.BackColor = Color.LightGray;
            EPC.ForeColor = Color.DarkOliveGreen;
            EPC.AutoSize = true;
            EPC.Name = "enter Target level";
            EPC.Text = "";
            EPC.KeyPress += new KeyPressEventHandler(EPC_KeyPress);
            add(EPC);
            //4
            TPC.Location = new Point(100, 200);
            TPC.BackColor = Color.LightGray;
            TPC.ForeColor = Color.DarkOliveGreen;
            TPC.AutoSize = true;
            TPC.Name = "enter Target level";
            TPC.Text = "";
            TPC.KeyPress += new KeyPressEventHandler(TPC_KeyPress);
            add(TPC);
            l1.Location = new Point(50, 50);
            l1.Text = "EXP";
            add(l1);
            l2.Location = new Point(50, 100);
            l2.Text = "Target";
            add(l2);
            l3.Location = new Point(50, 150);
            l3.Text = "Exp Per";
            add(l3);
            l4.Location = new Point(50, 200);
            l4.Text = "Time Per";
            add(l4);
            l5.Location = new Point(200, 200);
            l5.Text = "Nothing yet";
            l5.AutoSize = true;
            add(l5);
            l6.Location = new Point(200, 250);
            l6.Text = "Nothing yet";
            l6.AutoSize = true;
            add(l6);
            l7.Location = new Point(200, 300);
            l7.Text = "Nothing yet";
            l7.AutoSize = true;
            add(l7);
        }

        private void TPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            try
            {
                timePerCompetion = (float)Convert.ToDouble(TPC.Text + e.KeyChar.ToString());
                CheckCalculation();
            }
            catch
            {

            }
        }
        private void EPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            try
            {
                expPerCompletion = (float)Convert.ToDouble(EPC.Text + e.KeyChar.ToString());
                CheckCalculation();
            }
            catch
            {

            }
        }
        private void TL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            try
            {
                targlev = (float)Convert.ToDouble(TL.Text+e.KeyChar.ToString());
                //l5.Text = TL.Text+e.KeyChar.ToString();
                CheckCalculation();
            }
            catch
            {

            }
        }
        int j = 0;
        private void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            try
            {
                exp = (float)Convert.ToDouble(t.Text + e.KeyChar.ToString());
                CheckCalculation();
            }
            catch
            {

            }
        }
        void CheckCalculation()
        {
            CompletionChance = 100;
            try
            {
                l5.Text = Calculation.FullCalculator(exp, targlev, expPerCompletion,  timePerCompetion, CompletionChance, out TrueExpPerSecond,out float n, out float penis);
                l5.Text = "Exp Required: "+penis.ToString();
                l6.Text = "Completions required: "+n.ToString();
                l7.Text = "True EXP per second: " + TrueExpPerSecond.ToString();
            }
            catch { }
        }

    }
}
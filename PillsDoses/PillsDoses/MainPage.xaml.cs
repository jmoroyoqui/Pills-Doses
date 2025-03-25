namespace PillsDoses
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            int pillsCount;
            double dose;
            Result.IsVisible = false;
            Result.Text = string.Empty;
            
            if(!ValidatePills(txtPills.Text, out pillsCount))
            {
                return;
            }
            Calculate(pillsCount);
        }

        private bool ValidatePills(string pills, out int count)
        {
            count = 0;
            lblPills.Text = string.Empty;
            lblPills.IsVisible = false;
            txtPills.BackgroundColor = Colors.White;

            if (string.IsNullOrEmpty(pills))
            {
                lblPills.Text = "This field is required";
                lblPills.IsVisible = true;
                txtPills.BackgroundColor = Colors.LightPink;
                return false;
            }

            if (pills.Contains("."))
            {
                lblPills.Text = "Decimal numbers are not allowed";
                lblPills.IsVisible = true;
                txtPills.BackgroundColor = Colors.LightPink;
                return false;
            }

            if(!int.TryParse(pills, out count))
            {
                lblPills.Text = "Only numbers are allowed";
                lblPills.IsVisible = true;
                txtPills.BackgroundColor = Colors.LightPink;
                return false;
            }
            return true;
        }
        
        private void Calculate(int pills)
        {
            int dosesCount = 0;
            double quarters = 0;
            double halves = 0;

            double dose = 0.75;
            double total = 0.0;

            while(total < pills)
            {
                if ((total + dose) > pills) break;

                total += dose;
                dosesCount++;
                quarters++;
                halves++;
            }



            double remainer = pills - total;
            int totalHalves = (int)Math.Ceiling(halves / 2);
            int totalQuarters = (int)Math.Ceiling(quarters / 4);
            string nl = Environment.NewLine;
            Result.Text = $"Total doses: {dosesCount}" +
                $"{nl}{totalHalves} pills to create: {halves} halves" +
                $"{nl}{totalQuarters} pills to create: {quarters} quarters" +
                $"{nl}Remainer: {remainer / 0.25} quarters";
            Result.IsVisible = true;
        }
    }

}

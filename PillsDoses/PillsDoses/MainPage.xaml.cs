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
            int totalQuarters = pills * 4;

            int dose = totalQuarters / 3;
            int remainer = totalQuarters % 3;

            int halves = dose;
            int quarters = dose;

            string nl = Environment.NewLine;
            
            Result.Text = $"Total pills: {pills}" +
                $"{nl}Total doses (3/4): {dose}" +
                $"{nl}Halves needed: {halves}" +
                $"{nl}Quarters needed: {quarters}" +
                $"{nl}Remaining: {remainer}";
            Result.IsVisible = true;
        }
    }

}

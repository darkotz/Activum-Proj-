namespace PRG1_MAUI_ERP_Activum.View;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();
	}
    private double accumulator = 0;
    private string operation = "";
    private double operand = 0;
    private string expression = "";
    


    private void Numberbutton(object sender, EventArgs e)
    {
        var button = (Button)sender;
        if (button.Text == ",")
        {
            if (!expression.EndsWith("."))
                expression += ".";
        }
        else
        {
            expression += button.Text;
        }

        EntryCalculations.Text = expression;

        operand = double.Parse(
            GetLastNumber(),
            System.Globalization.CultureInfo.InvariantCulture
        );


    }

    private void OperandButton(object sender, EventArgs e)
    {
        var button = (Button)sender;

        if (accumulator == 0)
            accumulator = operand;
        else
            Calculate();

        operation = button.Text;

        expression += " " + button.Text + " ";
        EntryCalculations.Text = expression;
        operand = 0;
    }



    private void EqualButton(object sender, EventArgs e)
    {

        Calculate();
        expression += " =";
         EntryCalculations.Text = expression;
    }
    public void Calculate()
    {
        switch (operation)
        {
            case "+":
                accumulator += operand;
                break;
            case "-":
                accumulator -= operand;
                break;
            case "*":
                accumulator *= operand;
                break;

            case "/":

                if (operand == 0)
                {
                    EntryResult.Text = ("");
                    return;
                }
                accumulator /= operand;
                break;
        }

        EntryResult.Text = accumulator.ToString(System.Globalization.CultureInfo.InvariantCulture);
        operand = 0;
    }

    private void ClearButton(object sender, EventArgs e)
    {
        EntryCalculations.Text = "";
        EntryResult.Text = "";
        accumulator = 0;
        operand = 0;
    }
    private void ClearCloneButton(object sender, EventArgs e)
    {
        EntryCalculations.Text = "";
        expression = "";
        EntryResult.Text = "";

        operand = 0;
        accumulator = 0;
        
    }
    private void AnotherButton(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EntryCalculations.Text))
            return;

        if (EntryCalculations.Text.StartsWith("-"))
            EntryCalculations.Text = EntryCalculations.Text.Substring(1);
        else
            EntryCalculations.Text = "-" + EntryCalculations.Text;

        operand = double.Parse(
            EntryCalculations.Text,
            System.Globalization.CultureInfo.InvariantCulture
        );
    }
    private string GetLastNumber()
    {
        if (string.IsNullOrEmpty(expression))
            return "0";

        var parts = expression.Split(' ');
        return parts[^1];
    }

}

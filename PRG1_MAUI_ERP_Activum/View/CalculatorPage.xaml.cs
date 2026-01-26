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
            if (!GetLastNumber().Contains("."))
                expression += ".";
        }
        else
        {
            expression += button.Text;
        }

        EntryCalculations.Text = expression;

        double.TryParse(GetLastNumber(), out operand);

    }

    private void OperandButton(object sender, EventArgs e)
    {
        var button = (Button)sender;

        if (operation != "")
            Calculate();
        else
            accumulator = operand;

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

        operation = "";
        expression = "";
    }

     private void PercentageButton(object sender, EventArgs e)
    {
        operand /= 100;

        if (operation == "")
            accumulator = operand;

        expression = expression.TrimEnd() + "%";
        EntryCalculations.Text = expression;
        EntryResult.Text = operand.ToString();

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

        EntryResult.Text = accumulator.ToString();
        operand = 0;
    }

    private void ClearButton(object sender, EventArgs e)
    {
        EntryCalculations.Text = "";
        operand = 0;
        expression = "";
        operation = "";
    }
    private void ClearCloneButton(object sender, EventArgs e)
    {
        EntryCalculations.Text = "";
        operand = 0;
        expression = "";
        operation = "";
        EntryResult.Text = "";
        accumulator = 0;
    }
    
    private void AnotherButton(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(GetLastNumber()))
            return;

        if (GetLastNumber().StartsWith("-"))
            expression = expression.Replace(GetLastNumber(), GetLastNumber().Substring(1));
        else
            expression = expression.Replace(GetLastNumber(), "-" + GetLastNumber());

        EntryCalculations.Text = expression;
        double.TryParse(GetLastNumber(), out operand);
    }
    private string GetLastNumber()
    {
        if (string.IsNullOrEmpty(expression))
            return "0";

        var parts = expression.Split(' ');
        return parts[^1];
    }

}

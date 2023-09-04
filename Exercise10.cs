public class Exercise10
{
    static double Evaluate(string expression)
    {
        expression = (expression ?? "").Replace(" ", "");
        expression = expression.Replace(",", ".");

        var operatorStack = new Stack<char>();
        var outputQueue = new Queue<string>();
        Dictionary<char, int> precedence = new Dictionary<char, int>
        {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 }
        };

        for (int i = 0; i < expression.Length; i++)
        {
            if (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                string number = "";
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    number += expression[i++];
                }
                i--;  
                
                Console.WriteLine("Number: " + number);  // Debug line
                double parsedNumber = Convert.ToDouble(number);
                Console.WriteLine("Parsed number as double: " + parsedNumber);  // Debug line
                outputQueue.Enqueue(number); // Enqueue here only
                Console.WriteLine("Coda: " + string.Join(" ", outputQueue));
                /*if (double.TryParse(number, out parsedNumber))
                {
                    Console.WriteLine("Parsed number as double: " + parsedNumber);  // Debug line
                    outputQueue.Enqueue(parsedNumber.ToString()); // Enqueue here only
                }
                else
                {
                    throw new ArgumentException("Invalid number: " + number);
                }*/
            }
            else if ("+-*/".Contains(expression[i]))
            {
                while (operatorStack.Count > 0 && precedence.ContainsKey(operatorStack.Peek()) && precedence[expression[i]] <= precedence[operatorStack.Peek()])
                {
                    outputQueue.Enqueue(operatorStack.Pop().ToString());
                }
                operatorStack.Push(expression[i]);
            }
            else if (expression[i] == '(')
            {
                operatorStack.Push(expression[i]);
            }
            else if (expression[i] == ')')
            {
                while (operatorStack.Peek() != '(')
                {
                    outputQueue.Enqueue(operatorStack.Pop().ToString());
                }
                operatorStack.Pop();
            }
        }

        while (operatorStack.Count > 0)
        {
            outputQueue.Enqueue(operatorStack.Pop().ToString());
        }

        Console.WriteLine("Postfix: " + string.Join(" ", outputQueue));

        var evaluationStack = new Stack<double>();
        while (outputQueue.Count > 0)
        {
            string token = outputQueue.Dequeue();
            if (double.TryParse(token, out double num))
            {
                evaluationStack.Push(num);
            }
            else
            {
                double b = evaluationStack.Pop();
                double a = evaluationStack.Pop();
                double result = 0;
                switch (token)
                {
                    case "+":
                        result = a + b;
                        break;
                    case "-":
                        result = a - b;
                        break;
                    case "*":
                        result = a * b;
                        break;
                    case "/":
                        result = a / b;
                        break;
                }
                Console.WriteLine($"Debug: a = {a}, b = {b}, token = {token}");
                Console.WriteLine($"Performing operation: {a} {token} {b} = {result}");
                evaluationStack.Push(result);
            }
        }

        return evaluationStack.Pop();
    }

    public void EnterExpression()
    {
        Console.WriteLine("Enter an expression: ");
        string? expression = Console.ReadLine();

        try
        {
            if (!string.IsNullOrEmpty(expression))
            {
                double result = Evaluate(expression);
                Console.WriteLine("Result: " + result);
            }
            else
            {
                Console.WriteLine("Expression cannot be null or empty.");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid expression");
        }
    }
}

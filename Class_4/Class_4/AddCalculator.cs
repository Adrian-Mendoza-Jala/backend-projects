namespace Class_4
{

    public class AddCalculator
    {
        public static object AddValues(object value1, object value2)
        {
            if (value1.GetType() != value2.GetType())
            {
                throw new ArgumentException("Values are of different types.");
            }

            if (value1 is int || value1 is float || value1 is double || value1 is decimal)
            {
                return Convert.ToDouble(value1) + Convert.ToDouble(value2);
            }

            if (value1 is string)
            {
                return value1.ToString() + value2.ToString();
            }

            throw new ArgumentException("Data type not supported for addition.");
        }
    }
}

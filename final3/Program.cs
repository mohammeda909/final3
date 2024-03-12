/// This application is an Intake Form for a Health App.
/// Author: [mohammed ali]
/// purpose: creating an application for a health app
namespace HealthApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            string firstName = "";
            string lastName = "";
            int birthYear = 0;
            char gender = ' ';
            List<string> userResponses = new List<string>();

            // Input
            Console.WriteLine("Please fill out the following health information:");

            // Method for input validation
            firstName = GetValidInput("First Name: ");
            lastName = GetValidInput("Last Name: ");
            birthYear = GetValidBirthYear();

            gender = GetValidGender();

            // Questionnaire
            Console.WriteLine("Please answer the following health questions:");

            // Health-related questions
            string[] healthQuestions = {
                "Do you have any chronic health conditions? If so, please specify.",
                "Are you currently taking any medications? If yes, please list them.",
                "Do you have any allergies? If yes, please list them.",
                "Have you had any surgeries or medical procedures in the past? If yes, please describe.",
                "Do you smoke tobacco products? If yes, how many cigarettes per day?",
                "Do you consume alcohol? If yes, how often and in what quantities?",
                "How would you describe your typical diet? (e.g., vegetarian, omnivore, etc.)",
                "How often do you engage in physical activity or exercise?",
                "Have you experienced any significant weight changes in the past year? If yes, please describe.",
                "Do you have a family history of any hereditary health conditions? If yes, please specify."
            };

            // Collect user responses
            for (int i = 0; i < healthQuestions.Length; i++)
            {
                string response = GetValidInput($"{healthQuestions[i]} ");
                userResponses.Add(response);
            }

            // Profile Summary
            Console.WriteLine("Health Profile Summary:");
            Console.WriteLine($"Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetGenderDescription(gender)}");

            // Display Questions and Responses
            for (int i = 0; i < userResponses.Count; i++)
            {
                Console.WriteLine($"{healthQuestions[i]}: {userResponses[i]}");
            }
        }

        // Validate input for first name and last name
        static string GetValidInput(string prompt)
        {
            string input = "";
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            return input;
        }

        // Validate birth year input
        static int GetValidBirthYear()
        {
            int birthYear = 0;
            while (birthYear <= 1900 || birthYear > DateTime.Now.Year)
            {
                Console.Write("Birth Year: ");
                if (!int.TryParse(Console.ReadLine(), out birthYear))
                {
                    Console.WriteLine("Invalid input. Please enter a valid year.");
                }
            }
            return birthYear;
        }

        // Validate gender input
        static char GetValidGender()
        {
            char gender = ' ';
            while (gender != 'M' && gender != 'F' && gender != 'O')
            {
                Console.Write("Gender (M/F/O): ");
                gender = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            }
            return gender;
        }

        // Get gender description
        static string GetGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other";
                default:
                    return "Unknown";
            }
        }
    }
}

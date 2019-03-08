using System;
using System.Text;

namespace StudentLogic
{
    /// <summary>
    /// This class generates a random ID string of 3 chars followed by 6 ints.
    /// </summary>
    public class IdGenerator
    {
        /// <summary>
        /// Generates the identifier.
        /// </summary>
        /// <returns>The identifier.</returns>
        public string GenerateID()
        {
            string letters = RandomChars();
            string id = RandomNumbers().ToString();

            if (id.Length < 6) { id = AddPlaceHolders(id); }

            return letters + id;
        }

        /// <summary>
        /// Randomly generates the 3 chars.
        /// </summary>
        /// <returns>A three character string.</returns>
        private string RandomChars()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char c;

            for (int i = 0; i < 3; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(c);
            }

            return builder.ToString().ToLower();
        }

        /// <summary>
        /// Randomly generates the 6 ints.
        /// </summary>
        /// <returns>A six digit int.</returns>
        private int RandomNumbers()
        {
            Random random = new Random();
            int num = random.Next(999999);

            return num;
        }

        /// <summary>
        /// Adds place holder values of 0 to strings shorter than 6 digits.
        /// </summary>
        /// <returns>The place holders.</returns>
        /// <param name="id">Identifier.</param>
        private string AddPlaceHolders(string id)
        {
            if (id.Length < 6)
            {
                for (int i = id.Length; i < 6; i++)
                {
                    id = "0" + id;
                }
            }

            return id;
        }
    }
}

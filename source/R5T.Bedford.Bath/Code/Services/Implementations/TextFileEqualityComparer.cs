using System;
using System.IO;

using R5T.Bath;
using R5T.Magyar.IO;using R5T.T0064;


namespace R5T.Bedford.Bath
{[ServiceImplementationMarker]
    public class TextFileEqualityComparer : IFileEqualityComparer,IServiceImplementation
    {
        private IHumanOutput HumanOutput { get; }


        public TextFileEqualityComparer(IHumanOutput humanOutput)
        {
            this.HumanOutput = humanOutput;
        }

        public bool Equals(string filePath1, string filePath2)
        {
            bool output = true;

            string[] lines1 = FileHelper.ReadAllLines(filePath1);
            string[] lines2 = FileHelper.ReadAllLines(filePath2);

            output = this.CompareLineCounts(lines1, lines2);
            if (!output)
            {
                return output;
            }

            output = this.CompareLines(lines1, lines2);
            return output;

        }

        private void DetermineCharacterDifference(string line1, string line2)
        {
            // Assume at this point that line lengths are the same.
            int lineLength = line1.Length;
            for (int iChar = 0; iChar < lineLength; iChar++)
            {
                char line1Char = line1[iChar];
                char line2Char = line2[iChar];

                bool charMismatch = line1Char == line2Char;
                if (!charMismatch)
                {
                    string message = $@"Char mismatch: index: {iChar.ToString()}, line1: {line1Char.ToString()}, line2: {line2Char.ToString()}";
                    this.HumanOutput.WriteLine(message);
                }
            }
        }

        private bool CompareLineLength(string line1, string line2)
        {
            int line1Length = line1.Length;
            int line2Length = line2.Length;

            bool output = line1Length == line2Length;
            if (!output)
            {
                string message = $@"Line length mismatch: line1: {line1Length.ToString()}, line2: {line2Length.ToString()}";
                this.HumanOutput.WriteLine(message);
            }

            return output;
        }

        private void DetermineLineDifference(string line1, string line2)
        {
            // Assumes at this point the lines are not the same.
            bool lineLengthEqual = this.CompareLineLength(line1, line2);
            if (lineLengthEqual)
            {
                this.DetermineCharacterDifference(line1, line2);
            }
        }

        private bool CompareLines(string[] lines1, string[] lines2)
        {
            bool output = true;

            // Assumes at this point the line counts are the same.
            int nLines = lines1.Length;
            for (int iLine = 0; iLine < nLines; iLine++)
            {
                string line1 = lines1[iLine];
                string line2 = lines2[iLine];

                bool linesMatch = line1 == line2;
                if (!linesMatch)
                {
                    output = false;

                    string message = $@"Line mismatch. Line {(iLine + 1).ToString()}" + Environment.NewLine + line1 + Environment.NewLine + line2; // +1 to convert from zero-based to one-based line numbers.
                    this.HumanOutput.WriteLine(message);

                    this.DetermineLineDifference(line1, line2);
                }
            }

            return output;
        }

        private bool CompareLineCounts(string[] lines1, string[] lines2)
        {
            int nLines1 = lines1.Length;
            int nLines2 = lines2.Length;

            bool output = nLines1 == nLines2;
            if (!output)
            {
                string message = $@"File line count mismatch: {nLines1.ToString()} versus {nLines2.ToString()}.";
                this.HumanOutput.WriteLine(message);
            }

            return output;
        }
    }
}

using System;
using System.IO;

using R5T.Bath;


namespace R5T.Bedford.Bath
{
    public class BinaryFileEqualityComparer : IFileEqualityComparer
    {
        private IHumanOutput HumanOutput { get; }


        public BinaryFileEqualityComparer(IHumanOutput humanOutput)
        {
            this.HumanOutput = humanOutput;
        }

        public bool Equals(string filePath1, string filePath2)
        {
            bool output = true;

            byte[] file1 = File.ReadAllBytes(filePath1);
            byte[] file2 = File.ReadAllBytes(filePath2);

            output = this.CompareFileLengths(file1, file2);
            if (!output)
            {
                return output;
            }

            output = this.CompareFileContents(file1, file2);
            return output;
        }

        private bool CompareFileContents(byte[] file1, byte[] file2)
        {
            bool output = true;

            // Assume at this point that file lengths are equal.
            int nBytes = file1.Length;
            for (int iByte = 0; iByte < nBytes; iByte++)
            {
                byte value1 = file1[iByte];
                byte value2 = file2[iByte];

                bool valuesEqual = value1 == value2;
                if (!valuesEqual)
                {
                    output = false;

                    string message = $@"File byte value mismatch: index: {iByte}, file1: {value1.ToString()}, file2: {value2.ToString()}";
                    this.HumanOutput.WriteLine(message);
                }
            }

            return output;
        }

        private bool CompareFileLengths(byte[] file1, byte[] file2)
        {
            int nBytes1 = file1.Length;
            int nBytes2 = file2.Length;

            bool output = nBytes1 == nBytes2;
            if (!output)
            {
                string message = $@"File byte count mismatch: file1: {nBytes1.ToString()}, file2: {nBytes2.ToString()}";
                this.HumanOutput.WriteLine(message);
            }

            return output;
        }
    }
}

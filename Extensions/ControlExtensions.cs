using System.Runtime.InteropServices;

namespace OrmConfigGenerator.Extensions
{
    public static partial class ControlExtensions
    {
        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool LockWindowUpdate(IntPtr hWndLock);

        public static void SuspendDrawing(this Control control)
        {
            LockWindowUpdate(control.Handle);
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public static void ResumeDrawing(this Control control)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            LockWindowUpdate(IntPtr.Zero);
        }

        public static void HighlightQuestionMarks(this RichTextBox richTextBox)
        {
            richTextBox.SuspendDrawing();

            // Store the current selection to restore later
            int originalSelectionStart = richTextBox.SelectionStart;
            int originalSelectionLength = richTextBox.SelectionLength;

            // Clear previous formatting
            richTextBox.SelectAll();
            richTextBox.SelectionColor = richTextBox.ForeColor; // Default color
            richTextBox.SelectionBackColor = richTextBox.BackColor; // Default background color
            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);

            // Find all the question marks in the text
            int index = richTextBox.Text.IndexOf("???");
            while (index >= 0)
            {
                // Select the question mark and apply the highlighting
                richTextBox.Select(index, 3);
                richTextBox.SelectionColor = Color.Red;
                richTextBox.SelectionBackColor = Color.LightPink; // Default background color
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);

                // Move to the next occurrence
                index = richTextBox.Text.IndexOf("???", index + 1);
            }

            // Restore the original selection
            richTextBox.Select(originalSelectionStart, originalSelectionLength);
            richTextBox.ResumeDrawing();
        }
    }
}

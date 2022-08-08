using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LealPassword.Diagnostics
{
    public sealed class DiagnosticList
    {
        public static readonly DiagnosticList Instance = new DiagnosticList();

        public delegate void GeneratingDiagnostic(Diagnostic diagnostic);
        public event GeneratingDiagnostic DiagnosticGenerated;

        private readonly List<Diagnostic> _diagnostics;

        private DiagnosticList()
        {
            _diagnostics = new List<Diagnostic>();
        }

        private void Add(Diagnostic diagnostic)
        {
            DiagnosticGenerated?.Invoke(diagnostic);
            _diagnostics.Add(diagnostic);
        }

        public void Debug(string message, [CallerMemberName] string caller = "")
            => Add(new Diagnostic(DiagnosticType.DEBUG, caller, message));

        public void Warn(string message, Exception exception, [CallerMemberName] string caller = "")
            => Add(new Diagnostic(DiagnosticType.WARNING, caller, message, exception));

        public void Erro(string message, Exception exception, [CallerMemberName] string caller = "")
            => Add(new Diagnostic(DiagnosticType.ERROR, caller, message, exception));

        public void Fatl(string message, Exception exception, [CallerMemberName] string caller = "")
            => Add(new Diagnostic(DiagnosticType.FATAL, caller, message, exception));

        public ConsoleColor GetColor(DiagnosticType diagnosticType)
        {
            switch (diagnosticType)
            {
                case DiagnosticType.DEBUG: return ConsoleColor.Cyan;
                case DiagnosticType.WARNING: return ConsoleColor.Yellow;
                case DiagnosticType.ERROR: return ConsoleColor.Red;
                case DiagnosticType.FATAL: return ConsoleColor.Magenta;
                default: return ConsoleColor.Cyan;
            }
        }
    }
}
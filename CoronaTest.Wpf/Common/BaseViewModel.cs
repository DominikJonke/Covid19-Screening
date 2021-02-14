using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CoronaTest.Wpf.Common.Contracts;

namespace WPF.Common
{
    public abstract class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo, IValidatableObject
    {
        private bool _hasErrors;
        private bool _isValid;
        private bool _isChanged;
        protected readonly Dictionary<string, List<string>> Errors;
        private string _dbError;


        public IWindowController Controller { get; }

        public BaseViewModel(IWindowController controller)
        {
            Controller = controller;
            Errors = new Dictionary<string, List<string>>();
        }

        protected void Validate()
        {
            ClearErrors();
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this);
            Validator.TryValidateObject(this, validationContext, validationResults, true);
            if (validationResults.Any())
            {
                var propertyNames = validationResults.SelectMany(
                    validationResult => validationResult.MemberNames).Distinct().ToList();

                foreach (var propertyName in propertyNames)
                {
                    Errors[propertyName] = validationResults
                        .Where(validationResult => validationResult.MemberNames.Contains(propertyName))
                        .Select(r => r.ErrorMessage)
                        .ToList();

                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                }
            }
            HasErrors = Errors.Any();
            IsValid = Errors.Count == 0 && string.IsNullOrEmpty(DbError);
        }

        protected void ClearErrors()
        {
            DbError = "";
            foreach (var propertyName in Errors.Keys.ToList())
            {
                Errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return propertyName != null && Errors.ContainsKey(propertyName)
                ? Errors[propertyName]
                : Enumerable.Empty<string>();
        }

        public bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; OnPropertyChanged(); }
        }

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; OnPropertyChanged(); }
        }

        public bool IsChanged
        {
            get { return _isChanged; }
            set { _isChanged = value; OnPropertyChanged(); }
        }

        public String DbError
        {
            get { return _dbError; }
            set { _dbError = value; OnPropertyChanged(); }
        }

        public void AddErrorsToProperty(string property, List<string> errors)
        {
            Errors.Add(property, errors);
            HasErrors = Errors.Any();
            IsValid = Errors.Count == 0;
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(property));
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}

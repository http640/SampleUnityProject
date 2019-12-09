using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CheckInput : MonoBehaviour
{
    // Start is called before the first frame update
    public Collection.InputType inputType;
    public Text result;
    public InputField input;
    
    private bool _required;
    private int _minLength;
    private int _maxLength;
    private bool _validLength;
    private bool _validInput;

    private Regex _namePattern = new Regex(@"^[a-zA-Z]+[a-zA-Z]+([a-zA-Z\s])*$");
    private Regex _usernamePattern = new Regex(@"^[a-zA-Z_]\w*(\.[a-zA-Z_]\w*)*$");
    private Regex _passwordPatternHasNumber = new Regex(@"[0-9]+");
    private Regex _passwordPatternHasChar = new Regex(@"[a-zA-Z]+");
    private Regex _emailPattern = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
    private Regex _phoneNumberPattern = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
    private Regex _agePattern = new Regex(@"^\d?\d$");
    public void CheckValidInput()
    {
        if(inputType == Collection.InputType.name)
        {
            _minLength = 2;
            _maxLength = 25;
            _required = false;
            _validInput = _namePattern.IsMatch(input.text);
            
            
        }
        else if(inputType == Collection.InputType.username)
        {
            _minLength = 3;
            _maxLength = 9;
            _required = true;
            _validInput = _usernamePattern.IsMatch(input.text);
        }
        else if (inputType == Collection.InputType.password)
        {
            _minLength = 5;
            _maxLength = 18;
            _required = true;
            _validInput =
                _passwordPatternHasNumber.IsMatch(input.text) &&
                _passwordPatternHasChar.IsMatch(input.text);
        }
        else if (inputType == Collection.InputType.reEnterPassword)
        {
            _required = true;
            CheckMatchPasswords();
        }
        else if (inputType == Collection.InputType.email)
        {
            _minLength = 5;
            _maxLength = 35;
            _required = true;
            _validInput = _emailPattern.IsMatch(input.text);
        }
        else if (inputType == Collection.InputType.phoneNumber)
        {
            _minLength = 11;
            _maxLength = 11;
            _required = false;
            _validInput = _phoneNumberPattern.IsMatch(input.text);
        }
        else if (inputType == Collection.InputType.age)
        {
            _minLength = 1;
            _maxLength = 2;
            _required = false;
            _validInput = _agePattern.IsMatch(input.text);
        }
        else
        {
            Debug.Log("Input Type is not set");
        }
        _validLength = ValidLength();
        //print(inputType + " validaion is " + _validInput);
        ShowMassage();
    }
    public bool ValidLength()
    {
        return input.text.Length >= _minLength && input.text.Length <= _maxLength;
    }
    public bool CheckMatchPasswords()
    {
        return true;
    }

    public void ShowMassage()
    {
        if(_required && input.text == "") { result.text = Fa.faConvert("پر کردن این فیلد اجباریست!"); }
        else if (!_validLength && inputType != Collection.InputType.reEnterPassword) 
        { 
            if(_minLength != _maxLength)
                result.text = Fa.faConvert(" طول رشته باید حداقل " + _minLength.ToString() + " و حداکثر " + _maxLength.ToString() + " باشد. "); 
            else
                result.text = Fa.faConvert(" طول رشته ورودی باید تنها شامل " + _maxLength + " کاراکتر باشد ");
        }
        else if (!_validInput)
        {
            if(inputType == Collection.InputType.name)
            {
                result.text = Fa.faConvert("نام نمیتواند شامل عدد باشد");
            }
            if (inputType == Collection.InputType.username)
            {
                if (char.IsDigit(input.text[0]))
                    result.text = Fa.faConvert("نام کاربری نمیتواند با عدد شروع شود");
                else
                    result.text = Fa.faConvert("نام کاربری تنها میتواند شامل حروف و اعداد باشد");
            }
            if (inputType == Collection.InputType.password)
            {
                result.text = Fa.faConvert("رمز عبور باید حداقل یک حرف و یک عدد را شامل شود");
            }
            if (inputType == Collection.InputType.reEnterPassword)
            {
                result.text = Fa.faConvert("رمز عبور وارد شده مطابقت ندارد");
            }
            if (inputType == Collection.InputType.email)
            {
                result.text = Fa.faConvert("ایمیل وارد شده صحیح نمیباشد");
            }
            if (inputType == Collection.InputType.phoneNumber)
            {
                result.text = Fa.faConvert("شماره همراه وارد شده معتبر نمیباشد");
            }
            if (inputType == Collection.InputType.age)
            {
                result.text = Fa.faConvert("عدد وارد شده صحیح نمیباشد");
            }
        }
        else
        {
            result.text = "\u221A";
        }
       
    }
   
}

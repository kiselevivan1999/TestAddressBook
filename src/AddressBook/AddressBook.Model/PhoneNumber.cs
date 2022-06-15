﻿using System;
using System.Text.RegularExpressions;

namespace AddressBook.Model
{
    /// <summary>
    /// Описание номера телефона.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телфона.
        /// </summary>
        private string _number;

        /// <summary>
        /// Возвращает и задаёт номер телфона.
        /// </summary>
        public string Number 
        { 
            get => _number; 
            
            set 
            {
                string number = Regex.Replace(value.ToString(), "[^0-9]", ""); /* фильтровать - такое себе решение,
                                                                                * т.к. пользователь может набрать
                                                                                * вместо номера всякую дичь,
                                                                                * содержащую 11 цифр, первая из которых 7 или 8:
                                                                                * ывапш8вфзфа7фвап09а9пап-а7апыв099вап7в4ап и т.п.
                                                                                * Это как-то не похоже на номер телефона.*/

                if (!isValidated(number)) 
                {
                                                                        /*ну кого мы обманываем, какой +7 ?*/
                    throw new ArgumentException("Номер должен начинаться с +7, 7 или 8 и содержать 11 цифр");
                }
                _number = number; 
            } 
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="PhoneNumber"/>
        /// </summary>
        /// <param name="number"></param>
        public PhoneNumber(string number) 
        {
            Number = number;
        }

        /// <summary>
        /// Создаёт пустой экземпляр класса.
        /// </summary>
        public PhoneNumber() 
        {
         //без него не работает сохранение даных в файл (класс ProjectSerializer).   
        }

        /// <summary>
        /// Проверяет номер на соответствие необходимому формату.
        /// </summary>
        /// <param name="number">Проверяемый номер.</param>
        /// <returns>true - номер соответствует, false - номер не соответствует.</returns>
        private bool isValidated(string number)
        { 
            var regex = new Regex("^(7|8)[0-9]{10}$");

            return regex.IsMatch(number);
        }

        public override string ToString()
        {
            /*чёт много стринг ту стринг сабстринг подстринг, можно как-то оптимизировать?*/
            string number = Number.ToString();
            number = number.Length == 12 ? number.Substring(2) : number.Substring(1);  // так-так, а откуда 12?

            return string.Format("8 ({0}) {1}-{2} {3}", number.Substring(0, 3),
                number.Substring(3, 3), number.Substring(6, 2), number.Substring(8, 2));
        }
    }
}

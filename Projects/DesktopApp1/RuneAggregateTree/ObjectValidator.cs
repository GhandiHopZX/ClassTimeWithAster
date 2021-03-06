﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    class ObjectValidator
    {
        // use this for the Tokens

        /// <summary>Validates an object.</summary>
        /// <param name="value">The object to validate.</param>
        /// <exception cref="ValidationException">The value is invalid.</exception>
        public static void Validate(IValidatableObject value)
        {
            Validator.ValidateObject(value, new ValidationContext(value), true);

            //No access to instance members
            //_duh = 10;
        }

        //private int _duh;
    }
}

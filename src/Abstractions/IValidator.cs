﻿namespace Ocluse.LiquidSnow.Venus
{
    public interface IValidator<T>
    {
        Task<ValidationResult> Validate(T? value);
    }
}
﻿namespace InterviewPrep.Core.Exceptions;
public class BadRequestException : Exception
{
    public BadRequestException(string msg) : base(msg) { }
}

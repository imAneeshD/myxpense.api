using FluentValidation;
using MyXpense.Application.Features.Expenses.Commands.CreateExpense;

namespace MyXpense.Application.Features.Expenses.Validators;

public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(v => v.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");

        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(v => v.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.");

        RuleFor(v => v.ExpenseDate)
            .NotEmpty().WithMessage("ExpenseDate is required.");
    }
}

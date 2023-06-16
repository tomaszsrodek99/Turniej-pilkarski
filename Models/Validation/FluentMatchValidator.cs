using FluentValidation;
using Football.Context;
using Football.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models.Validation
{
    public class FluentMatchValidator : AbstractValidator<Match>
    {
        private readonly FootballDbContext _context;
        public FluentMatchValidator(FootballDbContext context, Match match)
        {
            _context = context;
            RuleFor(m => m)
                .Must(HaveOnlyOneMatchInEachStage)
                .WithMessage("Drużyna może rozegrać tylko jeden mecz na każdym kolejnym etapie.")
            .WithName("PlayStage");

            RuleFor(m => m.MatchDate)
        .NotNull().WithMessage("Data meczu jest wymagana.");

            RuleFor(m => m.HomeId)
        .NotEmpty().WithMessage("Gospodarze są wymagani.")
        .Must((match, homeId) => HaveUniqueMatchInGroupStage(match)).WithMessage("Drużyna może rozegrać tylko jeden mecz z każdym przeciwnikiem z tej samej grupy w fazie grupowej.");


            RuleFor(m => m.HomeScore)
                .NotNull().WithMessage("Uzupełnij.")
                .GreaterThanOrEqualTo(0);

            RuleFor(m => m.VisitorId)
        .NotEmpty().WithMessage("Goście są wymagani.")
        .Must((match, visitorId) => HaveUniqueMatchInGroupStage(match)).WithMessage("Drużyna może rozegrać tylko jeden mecz z każdym przeciwnikiem z tej samej grupy w fazie grupowej.");

            RuleFor(m => m.VisitorScore)
                .NotNull().WithMessage("Uzupełnij.")
                .GreaterThanOrEqualTo(0);

            RuleFor(m => m.PlayStage)
                .NotEmpty().WithMessage("Szczebel rozgrywek jest wymagany.");

            RuleFor(m => m.HomeScoreP)
            .GreaterThanOrEqualTo(0).When(m => m.HomeScoreP.HasValue)
            .Must((match, homeScoreP) => IsValidPenaltyShootoutResult(match)).WithMessage("Nieprawidłowy wynik rzutów karnych.");

            RuleFor(m => m.VisitorScoreP)
                .GreaterThanOrEqualTo(0).When(m => m.VisitorScoreP.HasValue)
                .Must((match, visitorScoreP) => IsValidPenaltyShootoutResult(match)).WithMessage("Nieprawidłowy wynik rzutów karnych.");
        }

        private bool HaveUniqueMatchInGroupStage(Match match)
        {
            if (match.PlayStage != Stage.Group.ToString())
                return true;

            // Sprawdź, czy drużyna ma już mecz z tym samym przeciwnikiem z grupy
            var existingMatch = _context.Matches
                .Any(m => m.PlayStage == Stage.Group.ToString()
                           && ((m.HomeId == match.HomeId && m.VisitorId == match.VisitorId)
                               || (m.HomeId == match.VisitorId && m.VisitorId == match.HomeId)));

            return !existingMatch;
        }

        private bool HaveOnlyOneMatchInEachStage(Match match)
        {
            var currentStage = match.PlayStage;

            // Jeśli aktualny etap to grupa, nie ma ograniczeń
            if (currentStage == Stage.Group.ToString())
                return true;

            // Sprawdź, czy drużyna ma już mecz w tym etapie
            var existingMatch = _context.Matches
                .Any(m => m.MatchID != match.MatchID && m.PlayStage == currentStage
                           && (m.HomeId == match.HomeId || m.VisitorId == match.HomeId));

            return !existingMatch;
        }
        private bool IsValidPenaltyShootoutResult(Match match)
        {
            if (!match.HomeScoreP.HasValue || !match.VisitorScoreP.HasValue)
                return true;

            if (match.HomeScoreP.Value == match.VisitorScoreP.Value)
                return false;

            if (match.HomeScoreP.Value >= 5 && match.VisitorScoreP.Value >= 5)
                return Math.Abs(match.HomeScoreP.Value - match.VisitorScoreP.Value) == 1;

            return Math.Abs(match.HomeScoreP.Value - match.VisitorScoreP.Value) == 2;
        }
    }
}

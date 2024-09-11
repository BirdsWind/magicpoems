namespace MagicPoems.Dtos;
public record class GetPoemDto(
    int id,
    string content,
    string author
);


public record class CreatePoemDto(
    string content,
    string author
);
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAI.GPT3.Interfaces;

/// <summary>
///     Given a prompt, the model will return one or more predicted completions, and can also return the probabilities of
///     alternative tokens at each position.
/// </summary>
public interface ICompletion
{
    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters
    /// </summary>
    /// <param name="createCompletionModel"></param>
    /// <returns></returns>
    Task<CompletionCreateResponse> Create(CompletionCreateRequest createCompletionModel);
}
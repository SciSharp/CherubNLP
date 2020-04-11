# CherubNLP
Natural Language Processing in .NET Standard.

```powershell
PM > Install-Package CherubNLP
```




#### Word Vector
#### Text Vector

#### Text Similarity

```csharp
using NumSharp;

var similarities = Similarity.Cosine("We can use Cosine to compute the similarity of two hardcoded lists.", new[]
            {
                "Cosine Similarity algorithm function sample.",
                "The Cosine Similarity function computes the similarity of two lists of numbers.",
                "Compute the similarity of two hardcoded lists.",
                "We can compute the similarity of two hardcoded lists.",
                "Coronavirus app could trace your contacts without sacrificing your privacy"
            }, "dbpedia.ftz"));

Assert.AreEqual(new[] { 0, 4, 1, 3, 2 }, np.argsort<double>(similarities));
```


# NAString
## What is it?
**N**o **A**llocations Reusable **String** (or **NAS**) is a simple system which allocates a string representation for `float`, `int` and `double` values, with formatting support like `0.0`.
### But then it allocates strings..
Yeah, it allocates the string once for each value every time you restart the game.

After the string has been allocated once, it's kept in memory until you stop the game.

The name may not suit it very well (`SAString` would be better), but it does what it says.
## How does it work?
It works by allocating the string representation of the value you passed using `NAString.Allocate(*)` which is then added to a internal readonly dictionary, then when you want to grab the string representation of a value, for example the float `5.5`, you can do so without the need of constantly converting it to a string and generating garbage.

An example:
```csharp
// Here we allocate the value
NAString.Allocate(5.5f);
// Now to display it on something like a TextMeshPRO component, we simply do
component.SetText(NAString.Borrow(5.5f));
```
And done, it's that simple.

If you want to avoid `Allocate()` and `Borrow()` visually, you can also use the extension methods, for example:
```csharp
// The 5.5f value isn't in the cache at first, but it will be after the first call
component.SetText(5.5f.ToNAString());
```
# License
The code is licensed under the MIT License.
Permissions:
* Commerical and Private use;
* Distribution;
* Modification

Conditions:
* License and copyright notice

Limitations:
* Liability;
* Warranty

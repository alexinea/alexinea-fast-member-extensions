<p>
    <a href="https://alexinea.com" target="_blank" title="FastMember Extensions">
        <img width="100" src="logo.png" />
    </a>
</p>

# FastMember Extensions

[![NuGet](https://img.shields.io/nuget/v/Alexinea.FastMember.Extensions.svg)](https://nuget.org/packages/Alexinea.FastMember.Extensions) 
[![Nuget](https://img.shields.io/nuget/dt/Alexinea.FastMember.Extensions.svg)](https://nuget.org/packages/Alexinea.FastMember.Extensions)

This project is an extension of [Alexinea.FastMember](https://github.com/alexinea/alexinea-fast-member). Read and write property based on [FastMember](https://github.com/mgravell/fast-member).

In addition, we also recommend that you use [Leo](https://github.com/night-moon-studio/leo) based on [NCC Natasha](https://github.com/dotnetcore/Natasha), a high-performance object reading and writing component.

## Installing

```
Install-Package Alexinea.FastMember.Extensions
```

## Usage

Get the value from the object.

```c#
var model = new Model();

var val1 = model.GetPropertyValue(typeof(Model), "PropertyName"); // model may be an object
var val2 = model.GetPropertyValue("PropertyName"); // model must be a specific type
var val3 = model.GetPropertyValue(t => t.PropertyName);
```

To set a value into the object.

```c#
var model = new Model();

model.SetPropertyValue(typeof(Model), "PropertyName", value); // model may be an object
model.SetPropertyValue("PropertyName", value); // model must be a specific type
model.SetPropertyValue(t => t.PropertyName, value);
```

## License

[Apache License 2.0](LICENSE)
﻿using Converter.MarkdownToBBCodeSteam;

namespace Converter.MarkdownToBBCode.Tests.Steam;

public class TestsHTML
{
    [Test]
    public void Converts_HTML_InlineEntity()
    {
        const string markdown = """
fdfsdf <b>This is a &auml; blank</b> sf
""";
        const string bbCode = """
fdfsdf [b]This is a ä blank[/b] sf
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }
    [Test]
    public void Converts_HTML_Inline()
    {
        const string markdown = """
foo <hr/> bar
""";
        const string bbCode = """
foo [hr][/hr] bar
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_Underscore()
    {
        const string markdown = """
<u>
dfgdfg
</u>

<ins>
dfgdfg
</ins>
""";
        const string bbCode = """
[u]
dfgdfg
[/u]
[u]
dfgdfg
[/u]
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }

    [Test]
    public void Converts_HTML_UnderscoreInline()
    {
        const string markdown = """
<u>dfgdfg</u>

<u><div>dfgdfg</div></u>

<ins>dfgdfg</ins>
""";
        const string bbCode = """
[u]dfgdfg[/u]

[u]dfgdfg[/u]

[u]dfgdfg[/u]
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }

    [Test]
    public void Converts_HTML_UnderscoreNested()
    {
        const string markdown = """
<u>
**Hello World!**
</u>

<ins>
**Hello World!**
</ins>
""";
        const string bbCode = """
[u]
[b]Hello World![/b]
[/u]
[u]
[b]Hello World![/b]
[/u]
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_Spoiler()
    {
        const string markdown = """
<details>
    <summary>Details</summary>
    Something small enough to escape casual notice.
</details>
""";
        const string bbCode = """
[b]Details[/b]
Something small enough to escape casual notice.
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }

    [Test]
    public void Converts_HTML_SpoilerMultiline()
    {
        const string markdown = """
<details>
    <summary>Details</summary>
    Something small enough to escape casual notice.
    Something small enough to escape casual notice.
</details>
""";
        const string bbCode = """
[b]Details[/b]
Something small enough to escape casual notice.
Something small enough to escape casual notice.
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }

    [Test]
    public void Converts_HTML_SpoilerNested()
    {
        const string markdown = """
<details>
  <summary>Xbox Game Pass PC</summary>
  <p>You need to copy content of '/bin/Gaming.Desktop.x64_Shipping_Client' from BLSE to 'Mount & Blade II- Bannerlord/Content/bin/Gaming.Desktop.x64_Shipping_Client'</p>
  <img src="https://media.discordapp.net/attachments/422092475163869201/1088721252702765126/image.png" alt="BLSE Installation Path" width="500">
  <p>You need to copy content of 'Modules/Bannerlord.Harmony' from Harmony to 'Mount & Blade II- Bannerlord/Content/Modules/Bannerlord.Harmony'</p>
  <img src="https://media.discordapp.net/attachments/422092475163869201/1088721253692616775/image.png" alt="Bannerlord.Harmony Installation Path" width="500">
</details>
""";
        const string bbCode = """
[b]Xbox Game Pass PC[/b]
You need to copy content of '/bin/Gaming.Desktop.x64_Shipping_Client' from BLSE to 'Mount & Blade II- Bannerlord/Content/bin/Gaming.Desktop.x64_Shipping_Client'
[img]https://media.discordapp.net/attachments/422092475163869201/1088721252702765126/image.png[/img]
You need to copy content of 'Modules/Bannerlord.Harmony' from Harmony to 'Mount & Blade II- Bannerlord/Content/Modules/Bannerlord.Harmony'
[img]https://media.discordapp.net/attachments/422092475163869201/1088721253692616775/image.png[/img]

""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_Nested()
    {
        const string markdown = """
# Bannerlord.BLSE
<p align="center">
  <a href="https://github.com/BUTR/Bannerlord.UIExtenderEx" alt="Logo">
    <img src="https://media.discordapp.net/attachments/422092475163869201/1083742477250465843/BLSE_SMALL_SMALL.png" />
  </a>
  </br>
</p>
""";
        const string bbCode = """
[h1]Bannerlord.BLSE[/h1]
[url=https://github.com/BUTR/Bannerlord.UIExtenderEx]
[img]https://media.discordapp.net/attachments/422092475163869201/1083742477250465843/BLSE_SMALL_SMALL.png[/img]
[/url]

""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }

    [Test]
    public void Converts_HTML_Nested2() // This path triggers Paragrap parsing
    {
        const string markdown = """
# Bannerlord.BLSE
<a href="https://github.com/BUTR/Bannerlord.UIExtenderEx" ><img alt="Logo" src="https://media.discordapp.net/attachments/422092475163869201/1083742477250465843/BLSE_SMALL_SMALL.png" /></a>
""";
        const string bbCode = """
[h1]Bannerlord.BLSE[/h1]
[url=https://github.com/BUTR/Bannerlord.UIExtenderEx][img]https://media.discordapp.net/attachments/422092475163869201/1083742477250465843/BLSE_SMALL_SMALL.png[/img][/url]
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_Line()
    {
        const string markdown = """
sfsdf
<hr/>
sdf
""";
        const string bbCode = """
sfsdf
[hr][/hr]
sdf
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_Quote()
    {
        const string markdown = """
<blockquote>sfsdf</blockquote>
""";
        const string bbCode = """
[quote]sfsdf[/quote]
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_Code()
    {
        const string markdown = """
<code>sfsdf</code>
""";
        const string bbCode = """
[code]sfsdf[/code]
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_List()
    {
        const string markdown = """
<ol>
  <li>sfsdf</li>
</ol>

<ul>
  <li>sfsdf</li>
</ul>
""";
        const string bbCode = """
[olist]
[*]sfsdf
[/olist]
[list]
[*]sfsdf
[/list]
""";
        Assert.That(MarkdownSteam.ToBBCodeExtended(markdown), Is.EqualTo(bbCode));
    }


    [Test]
    public void Converts_HTML_Heading()
    {
        const string markdown = """
<h1>One</h1>
<h2>Two</h2>
<h3>Three</h3>
<h4>Four</h4>
<h5>Five</h5>
<h6>Six</h6>
""";
        const string bbCode = """
[h1]One[/h1]
[h2]Two[/h2]
[h3]Three[/h3]
[h4]Four[/h4]
[h5]Five[/h5]
[h6]Six[/h6]
""";
        Assert.That(MarkdownSteam.ToBBCode(markdown), Is.EqualTo(bbCode));
    }
}
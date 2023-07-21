# Converter.MarkdownToBBCodeNM
Converts Markdown into NexusMods BBCode

### Installation
```shell
dotnet tool install -g Converter.MarkdownToBBCodeNM.Tool
```

### Example
When installed as a global tool:
```shell
markdown_to_bbcodenm -i "**raw markdown**"
markdown_to_bbcodenm -i "~~raw\r\nmarkdown~~" --disableextended

markdown_to_bbcodenm -i "/markdown.md";
markdown_to_bbcodenm -i "/markdown.md" -o "/bbcode.txt";
```
`-i or --input` accepts both raw markdown and a file path.  
`-o or --output` accepts a file path. If specified, will write the
converted BBCode to the file instead of outputting to the console.  
`-d or --disableextended` will disable newline detection via two spaces
and will disable HTML conversion

## Supporting Codes
| BBCode                                 | Markdown                                                                     | Implementation|
| -------------------------------------- | ---------------------------------------------------------------------------- | ------------- |
| [b]TEXT[/b]                            | \*\*TEXT\*\*                                                                 | Markdown      |
| [i]TEXT[/i]                            | \*TEXT\*                                                                     | Markdown      |
| [u]TEXT[/u]                            | \<ins\>TEXT\<\/ins\> OR \<u\>TEXT\<\/u\>                                     | HTML          |
| [s]TEXT[/s]                            | \~\~TEXT\~\~                                                                 | HTML          |
| [url=URL]TEXT[/url]                    | \[TEXT\]\(URL\)                                                              | Markdown      |
| [img]URL[/img]                         | \!\[Alt text\]\(URL\)                                                        | Markdown      |
| [quote]TEXT[/quote]                    | \> TEXT                                                                      | Markdown      |
| [quote AUTHOR]TEXT[/quote]             | \> TEXT                                                                      | Markdown      |
| [code]CODE[/code]                      | \`\`\`CODE\`\`\`                                                             | Markdown      |
| [list=1][*]ENTRY[/list]                | 1. ENTRY                                                                     | Markdown      |
| [list][*]ENTRY[/list]                  | \* ENTRY                                                                     | Markdown      |
| [line]                                 | \<hr\/\>                                                                     | HTML          |
| [color=COLOR]TEXT[/color]              |                                                                              | Not Possible  |
| [font=FONT]TEXT[/font]                 |                                                                              | Not Possible  |
| [center]TEXT[/center]                  | \<p align=\"center\"\>TEXT\<\/p\>                                            | HTML          |
| [right]TEXT[/right]                    | \<p align=\"right\"\>TEXT\<\/p\>                                             | HTML          |
| [left]TEXT[/left]                      | \<p align=\"left\"\>TEXT\<\/p\>                                              | HTML          |
| [size=1]TEXT[/size]                    | ###### TEXT                                                                  | Markdown      |
| [size=2]TEXT[/size]                    | ##### TEXT                                                                   | Markdown      |
| [size=3]TEXT[/size]                    | #### TEXT                                                                    | Markdown      |
| [size=4]TEXT[/size]                    | ### TEXT                                                                     | Markdown      |
| [size=5]TEXT[/size]                    | ## TEXT                                                                      | Markdown      |
| [size=6]TEXT[/size]                    | # TEXT                                                                       | Markdown      |
| [spoiler]TEXT[/spoiler]                | \<details\>\<summary\>Spoiler\<\/summary\>TEXT\<\/details\>                  | HTML          |
| [youtube]ID[/youtube]                  | [https://www.youtube.com/watch?v=ID](https://www.youtube.com/watch?v=ID\)    | Markdown      |

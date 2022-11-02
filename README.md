# GistNet
A small yet useful .Net library for manage GitHub Gists via API and in a very easy way!

## Table Of Content
  - [Features](#features)
  - [Installation](#installation)
  - [How to use](#how-to-use)
    - [Browse a Gist](#browse-a-gist)
      - [Custom page:](#custom-page)
      - [Custom page and results per page:](#custom-page-and-results-per-page)
      - [By date:](#by-date)
      - [All-In-One of above:](#all-in-one-of-above)
    - [Browse a Gist by ID](#browse-a-gist-by-id)
    - [Create a Gist](#create-a-gist)
    - [Update a Gist](#update-a-gist)
    - [Delete a Gist](#delete-a-gist)
    - [Rename files inside the Gist](#rename-files-inside-the-gist)
    - [Delete files inside the Gist](#delete-files-inside-the-gist)
    - [Get a revision of a Gist](#get-a-revision-of-a-gist)
  - [Known issues](#known-issues)
  - [Incoming features](#incoming-features)

## Features
- Browse Gists of any user or your own by ID, date, pagination and revision
- Create, edit and delete Gists
- Rename and delete Gists files
- More to come...

---
## Installation
1. Download the release
2. Add it as a dependency to your project
3. Copy and paste the code below
4. Enjoy!

---
## How to use
Just add these lines of code in your project!
Be careful, these examples are for **.Net 6** for use them in .Net Framework, you need to change any `new(...)` with `new ClassName(...)`
Also, ensure that your method is **async**.

---
### Browse a Gist
```c#
GistNet.Browse TheGist = new("YOUR_GITHUB_TOKEN", "RallyTuning");
string ReturnedString = await TheGist.GetAll();
```
In this case, you will get the last `30` (public) Gist of the selected username. If this is the owner of the token, you will get the last 30 public ***and*** secret Gists.

#### Custom page:
By adding and *int* after the *username*, you will be able to browse the pagination. In this case, you will get the `page 2` on the default `30 per page`.
```c#
GistNet.Browse TheGist = new("YOUR_GITHUB_TOKEN", "RallyTuning", 2);
```

#### Custom page and results per page:
In this case, `10` is the max results for each page, and `2` is the current page to fetch.
```c#
GistNet.Browse TheGist = new("YOUR_GITHUB_TOKEN", "RallyTuning", 10, 2);
```

#### By date:
It is possible to add a `DateTime` to show only Gists created or edited before the gived date.
In this example, will return only Gists post `2 November 2022 @ 18:20:00`.
```c#
GistNet.Browse TheGist = new("YOUR_GITHUB_TOKEN", "RallyTuning", new DateTime(2022, 11, 2, 18, 20, 0));
```

#### All-In-One of above:
Of course you can combine any of above, in this way:
```c#
GistNet.Browse TheGist = new("YOUR_GITHUB_TOKEN", "RallyTuning", new DateTime(2022, 11, 2, 18, 20, 0), 10, 2);
```

---
### Browse a Gist by ID
Easy as the name suggest, you will get a single Gist by the ID. (In this way, you will get also `history` and `forks` of the Gist)
```c#
GistNet.GetByID TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
string ReturnedString = await TheGist.Get();
```

---
### Create a Gist
```c#
private async void Button1_Click(object sender, EventArgs e)
{
    GistNet.Create TheGist = new("YOUR_GITHUB_TOKEN");
    TheGist.Content.IsPublic = true; // Or false for a secret Gist
    TheGist.Content.Description = "A short description of your Gist";
    TheGist.Content.Files.Add("Your new file.txt", new("Something cool inside the file"));
    TheGist.Content.Files.Add("Another file.txt", new("Something really really cool"));

    string ReturnedString = await TheGist.Push();
}
```

---
### Update a Gist
You can edit the Gist description and a content of any **existing** file, just "add" them inside the `Files list`.
```c#
GistNet.UpdateGist TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
TheGist.Content.Description = "New cool description";
TheGist.Content.Files.Add("Existing file.txt", new("New content..."));
TheGist.Content.Files.Add("Another existing file.txt", new("Another new content of the file..."));

string ReturnedString = await TheGist.Patch();
```

---
### Delete a Gist
```c#
GistNet.Delete TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
string ReturnedString = await TheGist.Confirm();
```
It will not return a JSON, but the StatusCodes of the HTTP Request.

---
### Rename files inside the Gist

```c#
GistNet.RenameFiles TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
TheGist.Content.Files.Add("Existing file.txt", new GistNet.RenameFiles.Details.FileContent("New name.txt"));

string ReturnedString = await TheGist.Patch();
```
It is possible to **rename** multiple files at once, just "add" them inside the `Files list`.

---
### Delete files inside the Gist
For delete a file(s), just "add" the name in the list and set the content of it to `null` or better, like the example, `new()`.

```c#
GistNet.DeleteFiles TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
TheGist.Content.Files.Add("File to delete.txt", new());
string ReturnedString = await TheGist.Patch();
```
It is possible to **delete** multiple files at once, just "add" them inside the `Files list`.

---
### Get a revision of a Gist
You can know the `SHA` of any Gist revision, by looking in the `history` node of any returned JSON.
```c#
GistNet.GetGistRevision TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID", "SHA_OF_THE_REVISION");
string ReturnedString = await TheGist.Get();
```


## Known issues

- Nothing yet 🥳


## Incoming features

- List starred gists
- List gist commits
- List gist forks
- Fork a gist
- Check if a gist is starred
- Star a gist
- Unstar a gist
<h1 align="center">GistNet</h1>
<p align="center">⭐ A small yet useful .Net library for manage GitHub Gists via API and in a very easy way!</p>

<div align="center">
  <a href="https://github.com/RallyTuning/GistNet/blob/main/LICENSE.md">
  <img alt="GPL 3.0 License" src="https://img.shields.io/github/license/RallyTuning/GistNet?label=License"/></a>
  <a href="https://github.com/RallyTuning/GistNet/releases">
  <img alt="Releases" src="https://img.shields.io/github/v/release/RallyTuning/GistNet?label=Release"/></a>
  <a href="https://github.com/RallyTuning/GistNet/releases">
  <img alt="Download" src="https://img.shields.io/github/downloads/RallyTuning/GistNet/total?color=%23d24dff&label=Downloads"/></a>
  <a href="https://github.com/RallyTuning/GistNet/stargazers">
  <img alt="Stars" src="https://img.shields.io/github/stars/RallyTuning/GistNet?color=%23ffff00&label=Stars"/></a>
  <a href="https://github.com/RallyTuning/GistNet/issues">
  <img alt="Issues" src="https://img.shields.io/github/issues-raw/RallyTuning/GistNet?label=Issues"/></a>
</div>
<br/>

✅ If you have some issues with the code, [open an issue](https://github.com/RallyTuning/GistNet/issues).\
✅ For questions, ideas, how-to, etc, please use the [discussions area](https://github.com/RallyTuning/GistNet/discussions), thanks!

## 🧭 Table Of Content
  - [Features](#-features)
  - [Installation](#-installation)
  - [How to use](#-how-to-use)
    - [Explore public Gists](#-explore-public-gists)
      - [By page](#by-page-pagination)
      - [By page and results per page](#by-page-and-results-per-page)
      - [By date](#by-date)
      - [By All-In-One of above](#by-all-in-one-of-above)
    - [Browse your own Gist](#-browse-your-own-gist)
    - [Browse a Gist by User](#-browse-gists-by-user)
    - [Browse a Gist by ID](#-browse-a-gist-by-id) 
    - [Create a Gist](#-create-a-gist)
    - [Update a Gist](#-update-a-gist)
    - [Delete a Gist](#-delete-a-gist)
    - [Rename files inside the Gist](#-rename-files-inside-the-gist)
    - [Delete files inside the Gist](#-delete-files-inside-the-gist)
    - [Get a revision of a Gist](#-get-a-revision-of-a-gist)
  - [Known issues](#-known-issues)
  - [Incoming features](#-incoming-features)

## ✨ Features
- Browse your own Gists or Gists of any user or by ID, date, pagination and revision
- Create, edit and delete Gists
- Rename and delete Gists files
- More to come...

---
## 🔌 Installation
0. Ensure that you have installed [.Net 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
1. Download the release
2. Add it as a dependency to your project
3. Copy and paste the code below
4. Enjoy!

---
## 📐 How to use
Just add these lines of code in your project!

Be careful, these examples are for **.Net 6**. For use them in .Net Framework, you need to change any `new(...)` with `new ClassName(...)`, example:\
`GistNet.Create TheGist = new("YOUR_GITHUB_TOKEN");` will be `GistNet.Create TheGist = new GistNet.Create("YOUR_GITHUB_TOKEN");`.

Also, ensure that your method is **async**, as the example: From this `private void Button1_Click` to this `private async void Button1_Click`.

---
### 🔭 Explore public Gists
```c#
GistNet.Explore ExploreCollection = new("YOUR_GITHUB_TOKEN");
string ReturnedString = await ExploreCollection.GetAll();
```
In this case, you will get your latest `30` Gists.

#### By page (pagination)
By adding and *int* after the *username*, you will be able to browse the pagination.\
In this case, you will get the `page 2` on the default `30 per page`.
```c#
GistNet.Explore ExploreCollection = new("YOUR_GITHUB_TOKEN", 2);
```

#### By page and results per page
In this case, `10` is the max results for each page, and `2` is the current page to fetch.
```c#
GistNet.Explore ExploreCollection = new("YOUR_GITHUB_TOKEN", 10, 2);
```

#### By date
It is possible to add a `DateTime` to show only Gists created or edited after the gived date.\
In this example, will return only Gists post `2 November 2022 @ 18:20:00`.
```c#
GistNet.Explore ExploreCollection = new("YOUR_GITHUB_TOKEN", new DateTime(2022, 11, 2, 18, 20, 0));
```

#### By All-In-One of above
Of course you can combine any of above, in this way:
```c#
GistNet.Explore ExploreCollection = new("YOUR_GITHUB_TOKEN", new DateTime(2022, 11, 2, 18, 20, 0), 10, 2);
```

---
### 👽 Browse your own Gist
```c#
GistNet.MyGists MyCollection = new("YOUR_GITHUB_TOKEN");
string ReturnedString = await MyCollection.GetAll();
```
In this case, you will get your latest `30` Gists.\
You can combine [by page or date](#by-page-pagination) same as the *Explore function*, just change `GistNet.Explore` with `GistNet.MyGists`.

---
### 🛀🏻 Browse Gists by user
```c#
GistNet.GetByUser UserCollection = new("YOUR_GITHUB_TOKEN", "RallyTuning");
string ReturnedString = await UserCollection.GetAll();
```
In this case, you will get the latest `30` (public) Gist of the selected username. (If this is the owner of the token, you will get the last 30 public ***and*** secret Gists).\
You can combine [by page or date](#by-page-pagination) same as the *Explore function*, just change `GistNet.Explore` with `GistNet.GetByUser`.

---
### 🆔 Browse a Gist by ID
Easy as the name suggest, you will get a single Gist by the ID. (In this way, you will get also `history` and `forks` of the Gist).
```c#
GistNet.GetByID TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
string ReturnedString = await TheGist.Get();
```

---
### ➕ Create a Gist
You can set the visibility, description and add as many files you want.
```c#
GistNet.Create TheGist = new("YOUR_GITHUB_TOKEN");
TheGist.Content.IsPublic = true; // Or false for a secret Gist
TheGist.Content.Description = "A short description of your Gist";
TheGist.Content.Files.Add("Your new file.txt", new("Something cool inside the file"));
TheGist.Content.Files.Add("Another file.txt", new("Something really really cool"));

string ReturnedString = await TheGist.Push();
```
It will return a JSON with the details of the new Gist.

---
### 🖍 Update a Gist
You can edit the Gist description and a content of any **existing** file, just "add" them inside the `Files` list.
```c#
GistNet.UpdateGist TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
TheGist.Content.Description = "New cool description";
TheGist.Content.Files.Add("Existing file.txt", new("New content..."));
TheGist.Content.Files.Add("Another existing file.txt", new("Another new content of the file..."));

string ReturnedString = await TheGist.Patch();
```

---
### ❌ Delete a Gist
```c#
GistNet.Delete TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
string ReturnedString = await TheGist.Confirm();
```
It will not return a JSON, but the StatusCodes of the HTTP Request.

---
### 🔤 Rename files inside the Gist

```c#
GistNet.RenameFiles TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
TheGist.Content.Files.Add("Existing file.txt", new GistNet.RenameFiles.Details.FileContent("New name.txt"));

string ReturnedString = await TheGist.Patch();
```
It is possible to **rename** multiple files at once, just "add" them inside the `Files` list.

---
### 📎 Delete files inside the Gist
For delete a file(s), just "add" the name in the list and set the content of it to `null` or better, like the example, `new()`.

```c#
GistNet.DeleteFiles TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID");
TheGist.Content.Files.Add("File to delete.txt", new());
string ReturnedString = await TheGist.Patch();
```
It is possible to **delete** multiple files at once, just "add" them inside the `Files` list.

---
### 📚 Get a revision of a Gist
You can know the `SHA` of any Gist revision, by looking in the `history` node of any returned JSON.
```c#
GistNet.GetGistRevision TheGist = new("YOUR_GITHUB_TOKEN", "GIST_ID", "SHA_OF_THE_REVISION");
string ReturnedString = await TheGist.Get();
```


## 🗑 Known issues

- Nothing yet 🥳


## 💡 Incoming features

- List starred gists
- List gist commits
- List gist forks
- Fork a gist
- Check if a gist is starred
- Star a gist
- Unstar a gist

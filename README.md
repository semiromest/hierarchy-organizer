# hierarchy-organizer

This Unity Editor tool allows you to create empty GameObjects to organize child objects in your scene based on a specified search string. It can be helpful for keeping your scene hierarchy clean and organized.

## Features

- Select multiple target objects in the Hierarchy window.
- Enter a search string to find child objects with matching names.
- Create empty GameObjects and group matching child objects under them.

## How to Use

1. Open Unity and make sure your project is set up.

2. In the Unity Editor, go to `Tools` in the top menu.

3. Select `Create Empty Objects with Children`.

4. In the tool's window:
   - Select target objects by selecting them in the Hierarchy window.
   - Enter a search string in the "Search String" field.
   - Click the "Organize" button.

5. Check the Console for a success message: "Organized successfully."

## Example

Let's say you have a set of objects with child objects in your scene. You want to organize the child objects with names containing "Arananİfade" under empty GameObjects. Here's how you can do it:

- Select the parent objects in the Hierarchy window.

- Enter "SearchString" in the "Search String" field.

- Click the "Organize" button.

- The tool will create empty GameObjects for each selected object and group child objects with names containing "Arananİfade" under them.

## Notes

- Make sure to save your scene after using this tool to retain the changes.

## Support

If you encounter any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.


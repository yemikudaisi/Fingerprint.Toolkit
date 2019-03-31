# Fingerprint.Toolkit
A simple fingerprint helper library for DigitalPersona fingerprint readers.

## Features
- Get all enrolled fingerprint as a collection.
- Read/Write a collection of fingerprints as an archive from/to a file.

## Todo
- Add verification support

## Example usage
See demo project for a working example.

```cs
public class Demo (){
    const string FILE_NAME= "fingerprint-collection.tarc";
    FingerprintTemplateCollection templatesCollection;

    public Demo()
    {
        templatesCollection = new FingerprintTemplateCollection();
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        EnrollmentView view = new EnrollmentView();
        view.MaxEnrollFingerCount = 2;
        view.EnrollmentCompleteEvent += View_EnrollmentCompleteEvent;
        view.ShowDialog();
    }

    private void ReadFingerprintArchiveFromFile()
    {
        if (File.Exists(FILE_NAME))
            templatesCollection =  TemplateArchiveHelper.GetTemplates(FILE_NAME);
    }
    
    private void WriteFingerprintArchiveToFile()
    {
        // Save templates collection as a archive
        TemplateArchiveHelper.SaveTemplateArchive(templatesCollection, FILE_NAME);
    }

    private void View_EnrollmentCompleteEvent(EnrollmentEventArgs e)
    {
        templatesCollection = e.Templates;
        WriteFingerprintArchiveToFile()
    }
}
````

## Issue Reporting

If you have found a bug or if you have a feature request, please report them by creating a new Issue.

## Author

[Yemi Kudaisi](https://github.com/yemikudaisi)

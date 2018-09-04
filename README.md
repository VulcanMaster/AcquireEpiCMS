# AcquireEpiCMS
Episerver CMS example

Before you start, remember that for example was used link:
 https://world.episerver.com/documentation/developer-guides/CMS/getting-started/creating-a-starter-project/  

 
How to begin? 

1. Create the administrator user into Windows users; 
2. Create the empty project; 
3. Run the project and add to the URL postfix /episerver and you will get the access to the administrator console of episerver; 
4. Login into administrator console of episerver with the administrator user which was created in previous steps; 

 
How to start the development? 
1. In \Model\Pages create the "Page Type" with the name StandardPage. Uncomment block with the property "Main Body" and add another one with type "String" and name "Heading"; 
2. Build the project and run. Then create the new page for the "Root", name the page "First Page" and after the click on button "Ok".  
3. Next follow dialog with editing the properties of the page. The view for the created page is still unavailable, because the view was not created, only the model based on class "PageData". 


Adding page rendering.
1. Create the controller. Select Add > New Item, then Episerver and Page Controller (MVC). Name the item StandardPageController.cs and click Add.
2. Create the View. Right-click on the Views folder, select Add > New Folder, and name it StandardPage. Right-click on the StandardPage folder, select Add > New item, and then Page Partial View (MVC Razor) under the Episerver group. Name the view Index.cshtml and click Add.

Configuring the start page.
1. Configure the site from the Episerver admin view.
2. Configure the site start page by going to Admin > Config > Manage Websites. Click Add site, and enter the site name and the site URL (localhost). 
3. Select a page in the page tree structure as start page, and click Save.

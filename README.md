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
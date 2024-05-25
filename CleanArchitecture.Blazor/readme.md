Blazor Render Modes
--------------------------------------------------
            
Server Side Modes
=================

# Static Server Side Render (SSR)
----------------------------------
    - its Default Render Mode For Blazor Components
    - its request full page from server and the full page rendered into server and result display in client browser like Razor Pages or MVC
    - its fast but need complete connection always with server
    - no interactivity between  client and server because its fully rendered into server
    - need to be online with server always
    - best for static pages that not need interactivity

# Stream Render (SR)  
---------------------------------------
    - its called Stream Render
    - its interactive render in server and update partial of ui of client
    - not need to render full page just piece of code or UI
    - its open connection with server using SignalR (Web Socket) for interactivity between client and server
    - need to be online with server always for interactivity
    - any reaction in client ui action sent to server to process it and take response to update ui only not full page just the interacted componenet
    - best for pages that need online and interactivity with user reaction like real time data



Client Side Modes
=================

# Client Side Render (CSR)
---------------------------
    - Dot Net Runtime and App Bundles will be Downloaded and Cached inside Browser 
    - Render will be made via Web Browser by Web Assembly
    - not need to be online with server it can be work as offline
    - first load take more time to download app bundles
    - best for offline pages with interactivity apps that use client resources

Auto Modes
==========

# Automatic Render (Auto)
-------------------------
    - Let Blazor Decided whice mode will be use server side or client side depend on many factors like browser or machine or speed of internet
    - First Time For Component will be used Interactive Server Side Render and in background will download and cache component in web assemblly
    - Second Time For Component will use cached version and using client side render for cached components



Interactivity Location
--------------------------------------------------
# Global Location
    - just set rendermode attribute to [App.razor] for (HeadOutlet) and (Routes) like below
     <HeadOutlet @rendermode="InteractiveAuto" />
     <Routes @rendermode="InteractiveAuto" />

    - no need to specify any render mode to any components they will be share render mode from app.razor
         

# Per Component Location
    - we need to set render mode directive to any component/page like below
      @rendermode InteractiveAuto
      @rendermode InteractiveServer
      @rendermode InteractiveWebAssembly
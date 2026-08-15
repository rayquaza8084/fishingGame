public class Bootstrapper
{
    //need to wait for all network objects to finish doing 
    //onstartclient()
    //once that is finished that means at least their networking stuff is initialized
    //certain classes/objects for example: Shopkeeper can be further initialized after being created
    //since things like shopkeeper will have UI for player
    //however since that is server side only 
    //the server side will not initialize that only client side
    //which is why its not full initialized when a shopkeeper is simply created 
}

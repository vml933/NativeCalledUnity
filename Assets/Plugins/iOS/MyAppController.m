//
//  MyAppController.m
//  Unity-iPhone
//
//  Created by WEN WEI LIN on 2017/12/18.
//

#import "MyAppController.h"
#import <Foundation/Foundation.h>

@implementation MyAppController

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
    [super application:application didFinishLaunchingWithOptions:launchOptions];
    
    if( [launchOptions objectForKey:UIApplicationLaunchOptionsURLKey]){
        //[self performSelector:@selector(openURLAfterDelay:) withObject:url afterDelay:2];
        self.launchedURL = [launchOptions objectForKey:UIApplicationLaunchOptionsURLKey];
    }
    return YES;
}

-(BOOL) application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options{
    UnitySendMessage("ParamHelper", "OnReceiveSchemeURL", [[url absoluteString] UTF8String]);
    return YES;
}


-(BOOL) application:(UIApplication *)application handleOpenURL:(NSURL *)url{
    UnitySendMessage("ParamHelper", "OnReceiveSchemeURL", [[url absoluteString] UTF8String]);
    self.launchedURL = url;
    return YES;
}

-(BOOL) application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation{
    
    self.launchedURL = url;
    return [super application:application openURL:url sourceApplication:sourceApplication annotation:annotation];
}

- (void)applicationDidBecomeActive:(UIApplication *)application {
    [super applicationDidBecomeActive:application];
    if(self.launchedURL){
        UnitySendMessage("ParamHelper", "OnReceiveSchemeURL", [[self.launchedURL absoluteString] UTF8String]);
        self.launchedURL = nil;
    }
}

@end
IMPL_APP_CONTROLLER_SUBCLASS(MyAppController)

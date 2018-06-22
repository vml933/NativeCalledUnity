//
//  MyAppController.h
//  Unity-iPhone
//
//  Created by WEN WEI LIN on 2017/12/18.
//

#import "UnityAppController.h"

@interface MyAppController : UnityAppController

@property (nonatomic, strong) NSURL *launchedURL;
-(BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
// ios 10.0+
-(BOOL) application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
// ios 2.0-9.0
-(BOOL) application:(UIApplication *)application handleOpenURL:(NSURL *)url;
// ios 4.2-9.0
-(BOOL) application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options;
- (void)applicationDidBecomeActive:(UIApplication *)application;
@end

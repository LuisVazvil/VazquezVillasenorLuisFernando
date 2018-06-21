// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface ModificarDiaController : UIViewController {
	UIButton *_btnGuardarDiaM;
	UIButton *_btnImageM;
	UIImageView *_imgAdjuntoM;
	UILabel *_lblDatoM;
	UITextField *_txtDatoM;
	UITextView *_txtDescripcionM;
	UITextField *_txtTituloM;
}

@property (nonatomic, retain) IBOutlet UIButton *btnGuardarDiaM;

@property (nonatomic, retain) IBOutlet UIButton *btnImageM;

@property (nonatomic, retain) IBOutlet UIImageView *imgAdjuntoM;

@property (nonatomic, retain) IBOutlet UILabel *lblDatoM;

@property (nonatomic, retain) IBOutlet UITextField *txtDatoM;

@property (nonatomic, retain) IBOutlet UITextView *txtDescripcionM;

@property (nonatomic, retain) IBOutlet UITextField *txtTituloM;

- (IBAction)btnBorrar:(id)sender;

@end

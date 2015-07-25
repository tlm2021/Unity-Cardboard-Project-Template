#!/bin/sh
echo ""
echo "Building JavaClass..."
javac JavaClass.java -bootclasspath $ANDROID_SDK_ROOT/platforms/android-8/android.jar -d .

echo ""
echo "Signature dump of JavaClass..."

javap -s org.example.ScriptBridge.JavaClass

echo "Creating JavaClass.jar..."
jar cvfM ../JavaClass.jar org/

echo ""
echo "Compiling NativeJavaBridge.cpp..."
$ANDROID_NDK_ROOT/ndk-build NDK_PROJECT_PATH=. NDK_APPLICATION_MK=Application.mk $*
mv libs/armeabi/libjavabridge.so ..

echo ""
echo "Cleaning up / removing build folders..."  #optional..
rm -rf libs
rm -rf obj
rm -rf org

echo ""
echo "Done!"

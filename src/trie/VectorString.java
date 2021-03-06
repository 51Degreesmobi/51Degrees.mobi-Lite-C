/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package FiftyOneDegreesTrieV3;

public class VectorString {
  private transient long swigCPtr;
  protected transient boolean swigCMemOwn;

  protected VectorString(long cPtr, boolean cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  protected static long getCPtr(VectorString obj) {
    return (obj == null) ? 0 : obj.swigCPtr;
  }

  protected void finalize() {
    delete();
  }

  public synchronized void delete() {
    if (swigCPtr != 0) {
      if (swigCMemOwn) {
        swigCMemOwn = false;
        FiftyOneDegreesTrieV3JNI.delete_VectorString(swigCPtr);
      }
      swigCPtr = 0;
    }
  }

  public VectorString() {
    this(FiftyOneDegreesTrieV3JNI.new_VectorString__SWIG_0(), true);
  }

  public VectorString(long n) {
    this(FiftyOneDegreesTrieV3JNI.new_VectorString__SWIG_1(n), true);
  }

  public long size() {
    return FiftyOneDegreesTrieV3JNI.VectorString_size(swigCPtr, this);
  }

  public long capacity() {
    return FiftyOneDegreesTrieV3JNI.VectorString_capacity(swigCPtr, this);
  }

  public void reserve(long n) {
    FiftyOneDegreesTrieV3JNI.VectorString_reserve(swigCPtr, this, n);
  }

  public boolean isEmpty() {
    return FiftyOneDegreesTrieV3JNI.VectorString_isEmpty(swigCPtr, this);
  }

  public void clear() {
    FiftyOneDegreesTrieV3JNI.VectorString_clear(swigCPtr, this);
  }

  public void add(String x) {
    FiftyOneDegreesTrieV3JNI.VectorString_add(swigCPtr, this, x);
  }

  public String get(int i) {
    return FiftyOneDegreesTrieV3JNI.VectorString_get(swigCPtr, this, i);
  }

  public void set(int i, String val) {
    FiftyOneDegreesTrieV3JNI.VectorString_set(swigCPtr, this, i, val);
  }

}

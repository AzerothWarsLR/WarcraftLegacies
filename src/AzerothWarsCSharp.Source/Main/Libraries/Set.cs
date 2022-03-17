//A traversable, unordered collection of integer.
//.list and .size can be used to traverse the Set.
namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Set{


    private Table index ;//Index location for each integer in the set
    private Table list  ;//Continous list of integers in the set. Index starts at 1
    readonly int size = 0;
    private string name;

    void destroy( ){
      index.destroy();
      list.destroy();
    }

    integer operator [](int index ){
      if (list[index] == 0){
        BJDebugMsg("ERROR: Set " + name + " " + I2S(this) + " Table index " + I2S(index) + " out of bounds");
        return 0;
      }
      return list[index];
    }

    void print( ){
      int i = 0;
      BJDebugMsg("Count: " + I2S(size));
      while(true){
        if ( i == size){ break; }
        BJDebugMsg(I2S(index[list[i]]) + " : " + I2S(list[i]));
        i = i + 1;
      }
    }

    boolean contains(int i ){
      if (index[i] != 0){
        return true;
      }else {
        if (list[index[i]] == i){
          return true;
        }
      }
      return false;
    }

    void add(int i ){
      if (!contains(i)){
        list[size] = i;
        index[i] = size;
        size = size + 1;
      }else {
        BJDebugMsg("ERROR: Set " + name + " already contains " + I2S(i));
      }
    }

    void remove(int i ){
      int removedIndex = index[i] ;//The index location of the integer being removed from the set
      int lastIndex = size - 1;
      int lastItem;
      if (contains(i)){
        if (removedIndex < lastIndex){                  //When we remove an item in the middle of the set, move the last item to the removed position (this keeps it continous)
          lastItem = list[lastIndex];
          list[removedIndex] = lastItem            ;//Set the item at the removed index to the last item
          index[lastItem] = removedIndex           ;//Set the index of the last item to the index of the removed item
          list[lastIndex] = 0                      ;//Dump the now-redundant item at the last index
        }else {
          list[removedIndex] = 0;
        }
        index[i] = 0                               ;//Remove the index for the item at the end
        size = size - 1;
      }else {
        BJDebugMsg("ERROR: Set " + name + " does !contain " + I2S(i));
      }
    }

    void discard(int i ){
      if (contains(i)){
        remove(i);
      }
    }

    thistype (string name ){

      size = 0;
      index = Table.create();
      list = Table.create();
      this.name = name;
      ;;
    }


  }
}

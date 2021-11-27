//A traversable, unordered collection of integer.
//.list and .size can be used to traverse the Set.
library Set requires Table

  struct Set
    private Table index //Index location for each integer in the set
    private Table list  //Continous list of integers in the set. Index starts at 1
    readonly integer size = 0
    private string name

    method destroy takes nothing returns nothing
      call index.destroy()
      call list.destroy()
    endmethod

    method operator [] takes integer index returns integer
      if list[index] == 0 then
        call BJDebugMsg("ERROR: Set " + name + " " + I2S(this) + " Table index " + I2S(index) + " out of bounds")
        return 0
      endif
      return list[index]
    endmethod
    
    method print takes nothing returns nothing
      local integer i = 0
      call BJDebugMsg("Count: " + I2S(size))
      loop
        exitwhen i == size
        call BJDebugMsg(I2S(index[list[i]]) + " : " + I2S(list[i]))
        set i = i + 1
      endloop
    endmethod

    method contains takes integer i returns boolean
      if index[i] != 0 then
        return true
      else
        if list[index[i]] == i then
          return true
        endif
      endif
      return false
    endmethod

    method add takes integer i returns nothing
      if not contains(i) then
        set list[size] = i
        set index[i] = size
        set size = size + 1
      else
        call BJDebugMsg("ERROR: Set " + name + " already contains " + I2S(i))
      endif
    endmethod

    method remove takes integer i returns nothing
      local integer removedIndex = index[i] //The index location of the integer being removed from the set
      local integer lastIndex = size - 1
      local integer lastItem
      if contains(i) then
        if removedIndex < lastIndex then                  //When we remove an item in the middle of the set, move the last item to the removed position (this keeps it continous)
          set lastItem = list[lastIndex]
          set list[removedIndex] = lastItem            //Set the item at the removed index to the last item
          set index[lastItem] = removedIndex           //Set the index of the last item to the index of the removed item
          set list[lastIndex] = 0                      //Dump the now-redundant item at the last index
        else
          set list[removedIndex] = 0
        endif
        set index[i] = 0                               //Remove the index for the item at the end
        set size = size - 1
      else
        call BJDebugMsg("ERROR: Set " + name + " does not contain " + I2S(i))
      endif
    endmethod

    method discard takes integer i returns nothing
      if contains(i) then
        call remove(i)
      endif
    endmethod

    static method create takes string name returns thistype
      local thistype this = thistype.allocate()
      set size = 0
      set index = Table.create()
      set list = Table.create()
      set this.name = name
      return this
    endmethod
  endstruct

endlibrary
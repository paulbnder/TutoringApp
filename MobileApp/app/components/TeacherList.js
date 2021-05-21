import React from 'react';
import {
  View, StyleSheet, FlatList, Pressable,
} from 'react-native';
import Animated, { useSharedValue, useAnimatedScrollHandler } from 'react-native-reanimated';
import { useTheme, useNavigation } from '@react-navigation/native';
import { AntDesign } from '@expo/vector-icons';

import Text from './Text';
import Teacher from './Teacher';

const AnimatedFlatList = Animated.createAnimatedComponent(FlatList);

// Horizontal list of teachers
function TeacherList({ teachers, title }) {
  const { width, margin, colors } = useTheme();
  const navigation = useNavigation();
  const scrollX = useSharedValue(0);

  // Handle horizontal scroll
  const scrollHandler = useAnimatedScrollHandler({
    onScroll: ({ contentOffset }) => {
      scrollX.value = contentOffset.x;
    },
  });

  const searchScreen = () => {
    navigation.push('teachersearch', {
      teacherList: teachers,
    });
  };

  // All styles
  const styles = StyleSheet.create({
    list: {
      backgroundColor: colors.card,
      paddingTop: (title === 'Reading' ? margin : 0),
    },
    heading: {
      paddingTop: margin,
      paddingHorizontal: margin,
      flexDirection: 'row',
      justifyContent: 'space-between',
    },
    listContainer: {
      padding: margin,
    },
    emptyContainer: {
      borderRadius: 20,
      alignItems: 'center',
      justifyContent: 'center',
      width: width - margin * 2,
      paddingVertical: margin * 2,
      backgroundColor: colors.background,
    },
    emptyText: {
      padding: margin,
    },
  });

  // Empty list placeholder
  const EmptyList = () => (
    <Pressable onPress={searchScreen} style={styles.emptyContainer}>
      <AntDesign color={colors.text} size={27} name="up" />
      <Text size={16} center style={styles.emptyText}>
        {'I\'m lonely. \n Add something here.'}
      </Text>
    </Pressable>
  );

  return (
    <View style={styles.list}>
      <View style={styles.heading}>
        <Text size={17} bold>{title}</Text>
        <Text size={17}>{teachers.length}</Text>
      </View>
      <AnimatedFlatList
        horizontal
        onScroll={scrollHandler}
        scrollEventThrottle={8}
        showsHorizontalScrollIndicator={false}
        contentContainerStyle={styles.listContainer}
        data={teachers}
        keyExtractor={(i) => i.id}
        renderItem={({ item, index }) => (
          <Teacher teacher={item} index={index} scrollX={scrollX} navigation={navigation} />
        )}
        ListEmptyComponent={<EmptyList />}
      />
    </View>
  );
}

export default React.memo(TeacherList);